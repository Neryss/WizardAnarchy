using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
        { 
            Debug.Log("Entered a trigger");
            DestroyProjectile();
        }
        if(col.CompareTag("Wall") || col.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
