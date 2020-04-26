using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMobs : MonoBehaviour
{
    public GameObject[] mobs;
    public float SpawnCd;
    private float spawnTimer;
    public Vector2 spawnArea;
    private Vector3 size;
    [Header("Spawn Markers")]
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    // Start is called before the first frame update
    void Start()
    {
        SpawnMobFromArray();
        Debug.Log(spawn1.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
    }

    private void SpawnMobFromArray()
    {
        int randomEnemy = Random.Range(0, mobs.Length);
        Instantiate(mobs[randomEnemy], spawn1.position, Quaternion.identity);
    }
}
