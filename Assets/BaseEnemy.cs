using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    private int maxHealth = 150;
    private int currentHealth;


    [SerializeField] private GameObject lootItemPrefab;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(lootItemPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
