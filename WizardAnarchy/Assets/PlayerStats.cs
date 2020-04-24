using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth;
    public int health;
    private EnemyHealth eHealth;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        eHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();
        if(eHealth != null)
        {
            Debug.Log("Ehealth");
        }
        if(health <= 0)
        {
            
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        health =- damage;
    }
}
