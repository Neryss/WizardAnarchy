using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameScript : MonoBehaviour
{
    public PlayerShooting pShooting;
    public Transform firePoint;
    public GameObject muzzleEffect;
    public EnemyHealth enemyHealth;
    public int damage;
    void Start()
    {
        pShooting = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
        firePoint = pShooting.firePoint.transform;
        Instantiate(muzzleEffect, firePoint.position, Quaternion.identity);
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
}
