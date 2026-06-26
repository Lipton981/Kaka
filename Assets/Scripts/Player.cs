using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController cc;
    public float speed = 5f;
    public float jumpForce = 5f;
    public float gravity = -20f;
    public Transform pidor;
    public float kaka = 2f;
    float y;
    float xRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * kaka;
        float mouseY = Input.GetAxis("Mouse Y") * kaka;
        transform.Rotate(0, mouseX, 0);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        pidor.localRotation = Quaternion.Euler(xRotation, 0, 0);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        cc.Move(move * speed * Time.deltaTime);
        if (cc.isGrounded)
        {
            y = -1f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                y = jumpForce;
            }
        }

        y += gravity * Time.deltaTime;
        Vector3 gravityMove = new Vector3(0, y, 0);
        cc.Move(gravityMove * Time.deltaTime);
    }
}
