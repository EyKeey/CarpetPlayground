using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public float maxHealth;
    [SerializeField] private float currentHealth;

    private void Start()
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
        Time.timeScale = 0;
        Debug.Log("Player died");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player collided with " + other.gameObject.name);
        ICollectableItem collectableItem = other.gameObject.GetComponent<ICollectableItem>();
        if (collectableItem != null)
        {
            Debug.Log("Player collected " + other.gameObject.name);
            collectableItem.Collect();
        }
    }
}
