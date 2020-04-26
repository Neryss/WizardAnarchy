using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameManager gameManager;
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
            gameManager.GameOver();
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        health -= damage;
    }
}
