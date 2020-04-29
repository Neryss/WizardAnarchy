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
        pShooting = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
        aimingScript = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Aiming>();
        //angle = aimingScript.fireAngle;
        //need to reference the rotation of the chil rotationPoint so I can apply it to the effect
        firePoint = pShooting.firePoint.transform;
        Instantiate(muzzleEffect, firePoint.position, Quaternion.Euler(angle, 0, 0));
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