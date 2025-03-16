using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector] public float maxHealth;
    [SerializeField] private float currentHealth;

    [HideInInspector] public bool isRegenerationActive = false;
    [HideInInspector] public float regenerationRate = 0;
    [HideInInspector] public float regenerationCooldown = 8f;
    private float lastRegenerationTime = 0;

    private void Start()
    {
        currentHealth = maxHealth;
        UIManager.instance.UpdateHealthBar(currentHealth, maxHealth);
    }

    private void Update()
    {
        if (isRegenerationActive && Time.time - lastRegenerationTime > regenerationCooldown)
        {
            Regenerate();
            lastRegenerationTime = Time.time;
        }
      
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UIManager.instance.UpdateHealthBar(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Regenerate()
    {
        currentHealth += currentHealth * regenerationRate;
        UIManager.instance.UpdateHealthBar(currentHealth, maxHealth);
    }

    private void Die()
    {
        Time.timeScale = 0;
        Debug.Log("Player died");
    }

    
}
