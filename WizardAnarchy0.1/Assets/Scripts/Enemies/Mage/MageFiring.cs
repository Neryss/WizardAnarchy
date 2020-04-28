using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageFiring : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireCd;
    private float cdCount;
    public float bulletSpeed;
    private Rigidbody2D bulletRB;
    // Start is called before the first frame update
    void Start()
    {
        cdCount = fireCd;
    }

    // Update is called once per frame
    void Update()
    {
        if(cdCount <= 0)
        {
            cdCount = fireCd;
            EnemyShoot();
        }
        else
        {
            cdCount -= Time.deltaTime;
        }
    }

    private void EnemyShoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);
    }
}
