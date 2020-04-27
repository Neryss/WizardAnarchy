using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMobs : MonoBehaviour
{
    public GameObject[] mobs;
    public float spawnCd;
    private float spawnTimer;
    private Vector3 spawnArea;
    private Vector3 size;
    private Vector3 randomPos;
    private int randomEnemy;
    public GameObject spawnEffect;
    [Header("Spawn Markers")]
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    // Start is called before the first frame update
    void Start()
    {
        spawnArea = new Vector3(spawn2.position.x, spawn3.position.y, 0);
        spawnTimer = spawnCd;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTimer <= 0)
        {
            spawnTimer = spawnCd;
            SpawnMobFromArray();
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    private void SpawnMobFromArray()
    {
        randomPos = RandomRangeVector3(spawn1.position, spawnArea);
        randomEnemy = Random.Range(0, mobs.Length);
        GameObject tempSpawnEffect = Instantiate(spawnEffect, randomPos, Quaternion.identity);
        Invoke("InstantiateMob", 4);
        Destroy(tempSpawnEffect, 3);
    }

    public Vector3 RandomRangeVector3(Vector3 min, Vector3 max)
    {
        Vector3 res = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, min.z));
        return (res);
    }

    private void InstantiateMob()
    {
        Instantiate(mobs[randomEnemy], randomPos, Quaternion.identity);
    }
}
