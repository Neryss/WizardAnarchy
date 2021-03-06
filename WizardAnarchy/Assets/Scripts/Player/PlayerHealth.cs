﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameManager gameManager;
    public int maxHealth;
    public int health;
    public bool alive;
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            alive = false;
            KillPlayer();
            gameManager.GameOver();
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        health -= damage;
    }

    public void KillPlayer()
    {
        Destroy(gameObject);
    }
}
