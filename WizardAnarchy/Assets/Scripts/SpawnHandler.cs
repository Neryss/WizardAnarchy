using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    public bool isOn;
    public GameObject[] mobs;
    [Header("Wave Tweaks")]
    public float spawnCd;
    private int eCounter;
    public int maxWave;
    private int waveCounter;
    public int maxEntityPerWave;
    private float spawnTimer;
    private int randomEnemy;
    //public GameObject spawnEffect;
    [Header("Spawn Markers")]
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    private Vector3 spawnArea;
    private Vector3 size;
    private Vector3 randomPos;
    // Start is called before the first frame update
    void Start()
    {
        spawnArea = new Vector3(spawn2.position.x, spawn3.position.y, 0);
        spawnTimer = spawnCd;
    }

    // Update is called once per frame
    void Update()
    {
        if(isOn)
        {
            WaveSpawn();
        }
    }

    //looks really shitty af but it gets the work done for now
    //added possibility to change which enemies spawn depending on the wave, also handle some errors
    //need to implement the change wave system and UI
    private void SpawnMobFromArray(int min, int max)
    {
        if(max > mobs.Length || min > mobs.Length)
        {
            Debug.LogError("min or max was out of array");
        }
        else
        {
            randomPos = RandomRangeVector3(spawn1.position, spawnArea);
            randomEnemy = Random.Range(min, max);
            Instantiate(mobs[randomEnemy], randomPos, Quaternion.identity);
        }
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

    private void WaveSpawn()
    {
        int minMobIndex = 0;
        if(eCounter <= maxEntityPerWave)
        {
            if(spawnTimer <= 0)
            {
                spawnTimer = spawnCd;
                SpawnMobFromArray(minMobIndex, mobs.Length);
                eCounter++;
            }
            else
            {
                spawnTimer -= Time.deltaTime;
            }
        }
        else if(eCounter > maxEntityPerWave)
        {
            eCounter = 0;
            waveCounter++;
            spawnTimer = spawnCd + 7f;      //kinda cool time btw waves(UI display for exemple)
            print("Wave counter: " + waveCounter + "spawn timer: " + spawnTimer);
        }
    }
}
