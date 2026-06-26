using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject vragprefab;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= Slozhnost.spawnTime)
        {
            Instantiate(vragprefab, transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
