using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

public class Slozhnost : MonoBehaviour
{
    public static float enemyHp = 100;
    public static float enemyDamage = 10;
    public static float spawnTime = 2;
    public static float enemySpeed = 2;
    public static int winkills = 10;
    public VideoPlayer video;
    public GameObject videoObema;

    public GameObject panel;

    void Start()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void Easy()
    {
        enemyHp = 50;
        enemyDamage = 5;
        spawnTime = 3;
        enemySpeed = 2;
        winkills = 10;


        panel.SetActive(false);
        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Normal()
    {
        enemyHp = 100;
        enemyDamage = 10;
        spawnTime = 2;
        enemySpeed = 4;
        winkills = 20;

        panel.SetActive(false);
        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Hard()
    {
        enemyHp = 150;
        enemyDamage = 15;
        spawnTime = 1;
        enemySpeed = 6;
        winkills = 40;

        panel.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

}
