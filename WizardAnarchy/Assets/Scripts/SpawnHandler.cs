using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    public GameObject[] mobs;
    public float spawnCd;
    private int eCounter;
    public int maxEntityPerWave;
    private float spawnTimer;
    private Vector3 spawnArea;
    private Vector3 size;
    private Vector3 randomPos;
    private int randomEnemy;
    public bool isOn;
    //public GameObject spawnEffect;
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
        if(isOn && eCounter <= maxEntityPerWave)
        {
            if(spawnTimer <= 0)
            {
                spawnTimer = spawnCd;
                SpawnMobFromArray();
                eCounter++;
            }
            else
            {
                spawnTimer -= Time.deltaTime;
            }
        }
    }

    //looks really shitty af but it gets the work done for now
    private void SpawnMobFromArray()
    {
        randomPos = RandomRangeVector3(spawn1.position, spawnArea);
        randomEnemy = Random.Range(0, mobs.Length);
        Instantiate(mobs[randomEnemy], randomPos, Quaternion.identity);
        //GameObject tempSpawnEffect = Instantiate(spawnEffect, randomPos, Quaternion.identity);      // I fear no man
        //Invoke("InstantiateMob", 6);                                                                // But this..
        //Destroy(tempSpawnEffect, 6);                                                                // It scares me..
    }

    public Vector3 RandomRangeVector3(Vector3 min, Vector3 max)
    {
        Vector3 res = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, min.z));
        return (res);
    }

    private void InstantiateMob()
    {
        Instantiate(mobs[randomEnemy], randomPos, Quaternion.identity);
        Debug.Log("Instantiate at " + randomPos);
    }
}
