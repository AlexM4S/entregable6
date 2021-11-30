using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Vector3 spawnPosLat = new Vector3(-14, 0, 0);
    public float randomX;
    public float randomY;
    public float limsLat = 8;
    public float limsTop = 4;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 2, 1.5f);
    }

    
    public void SpawnObstacle()
    {
        randomX = Random.Range(-limsLat, limsLat);
        randomY = Random.Range(-limsTop, limsTop);
        spawnPosLat = new Vector3(randomX, 0, 0);
        Instantiate(obstaclePrefab, spawnPosLat, obstaclePrefab.transform.rotation);
    }
}
