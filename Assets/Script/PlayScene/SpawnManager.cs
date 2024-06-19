using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public float spawnInterval = 2f;
    public GameObject leftPoint;
    public GameObject rightPoint;

    private float nextSpawn;
    private float minX;
    private float maxX;

    void Start()
    {
        nextSpawn = Time.time + spawnInterval;
        minX = leftPoint.transform.position.x;
        maxX = rightPoint.transform.position.x;
    }

    void Update()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }
        if (Time.time > nextSpawn)
        {
            Spawn();
            nextSpawn = Time.time + spawnInterval;
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

        GameObject enemy = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnPosition, Quaternion.Euler(0, 180, 0));
        // enemy.transform.parent = transform;
    }
}
