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
        pShooting = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
        rotationTrans = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);
        //need to reference the rotation of the chil rotationPoint so I can apply it to the effect
        print(rotationTrans.rotation);
        firePoint = pShooting.firePoint.transform;
        Instantiate(muzzleEffect, firePoint.position, Quaternion.Euler(rotationTrans.transform.rotation.x, rotationTrans.transform.rotation.y, rotationTrans.transform.rotation.z));
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