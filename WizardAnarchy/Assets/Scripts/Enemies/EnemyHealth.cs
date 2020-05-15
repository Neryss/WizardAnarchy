using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public ShakeCameraController shakeController;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        shakeController = Camera.main.GetComponent<ShakeCameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            shakeController.StartShake(.1f, .1f);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        shakeController.StartShake(.1f, .05f);
    }

    public void KillEntity(GameObject entity)
    {
        Destroy(entity);
    }
}
