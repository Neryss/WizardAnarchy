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
        //Not getting the wanted rotation (got the z since it's the only one changing on the rotation point so doesn't work)
        print(rotationTrans.transform.rotation.z);
        firePoint = pShooting.firePoint.transform;
        Instantiate(muzzleEffect, firePoint.position + new Vector3(0, 0, -1), Quaternion.Euler(rotationTrans.rotation.x, rotationTrans.transform.rotation.y, rotationTrans.transform.rotation.z));
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