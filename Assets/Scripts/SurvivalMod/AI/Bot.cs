using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [Header("Bot Settings")]
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    [Header("Prefabs")]
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private GameObject lootObjPrefab;
    

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Instantiate(lootObjPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);        
    }
}
