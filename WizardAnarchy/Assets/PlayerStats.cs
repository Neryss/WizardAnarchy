using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public EnemyHealth enemyHealth;
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
            enemyHealth.Kill(gameObject);
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        health =- damage;
    }
}
