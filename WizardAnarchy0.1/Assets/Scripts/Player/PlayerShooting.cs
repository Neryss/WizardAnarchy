using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject fireMuzzle;
    public Transform firePoint;
    public float bulletForce;
    private Rigidbody2D bulletRb;
    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerShot();
        }
    }

    private void PlayerShot()
    {
        GameObject tempMuzzle = Instantiate(fireMuzzle, firePoint.position, Quaternion.identity);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        Destroy(tempMuzzle, 2);
    }
}
