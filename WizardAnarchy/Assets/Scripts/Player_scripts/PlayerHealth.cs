using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public EnemyHealth eHealth;
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
            eHealth.KillEntity(gameObject);
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        health -= damage;
    }
}
