using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hexball : MonoBehaviour
{
    public PlayerHealth pHealth;
    public int damage;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            col.GetComponent<PlayerHealth>().PlayerTakeDamage(damage);
            Destroy(gameObject);
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
