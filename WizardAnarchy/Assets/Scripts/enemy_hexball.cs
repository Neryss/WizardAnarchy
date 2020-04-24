using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hexball : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player") || col.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
