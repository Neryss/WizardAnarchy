using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameScript : MonoBehaviour
{
    public PlayerShooting pShooting;
    public Transform rotationTrans;
    public GameObject playerGO;
    public Aiming aimingScript;
    public Transform firePoint;
    public float angle;
    public GameObject muzzleEffect;
    public EnemyHealth enemyHealth;
    public int damage;
    void Start()
    {
        SpawnMuzzle();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
        {
            col.GetComponent<EnemyHealth>().TakeDamage(damage);
            DestroyProjectile();
        }
        if(col.CompareTag("Wall"))
        {
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void SpawnMuzzle()
    {
        pShooting = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
        rotationTrans = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);
        firePoint = pShooting.firePoint.transform;
        Instantiate(muzzleEffect, firePoint.position + new Vector3(0, 0, -1), Quaternion.LookRotation(firePoint.position - rotationTrans.position));
    }
}