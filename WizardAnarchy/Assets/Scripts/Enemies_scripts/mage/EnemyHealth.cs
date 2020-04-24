using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Kill(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health =- damage;
    }

    public void Kill(GameObject entity)
    {
        Destroy(entity);
    }
}
