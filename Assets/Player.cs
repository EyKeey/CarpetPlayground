using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int maxHealth = 400;
    private int currentHealth;

    private int damage = 75;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<BaseEnemy>().TakeDamage(damage);
        }
    }
    
}
