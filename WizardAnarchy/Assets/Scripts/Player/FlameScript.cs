using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameScript : MonoBehaviour
{
    public PlayerShooting pShooting;
    public Aiming aimingScript;
    public Transform firePoint;
    public float angle;
    public GameObject muzzleEffect;
    public EnemyHealth enemyHealth;
    public int damage;
    void Start()
    {
        pShooting = gameObject.GetComponent<PlayerShooting>();
        aimingScript = gameObject.GetComponent<Aiming>();
        angle = aimingScript.fireAngle;
        print(angle);
        firePoint = pShooting.firePoint.transform;
        Instantiate(muzzleEffect, firePoint.position, Quaternion.Euler(0, 0, angle));
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