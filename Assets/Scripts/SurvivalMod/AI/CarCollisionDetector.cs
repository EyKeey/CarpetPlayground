using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollisionDetector : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private AudioClip crashSound;

    private BotChaseToPlayer botCTP;
    private Rigidbody rb;
    private float collisionWaitTime = 3f;

    private AudioSource audioSource;

    private void Start()
    {
        botCTP = GetComponent<BotChaseToPlayer>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        botCTP.currentSpeed = 0;
        botCTP.targetSpeed = 0;
        rb.velocity = Vector3.zero;
        PlayCrashSound();
        HandleCollision();

        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        if(collision.gameObject.CompareTag("Bot"))
        {
            collision.gameObject.GetComponent<Bot>().TakeDamage(damage);
        }
    }

    private void HandleCollision()
    {
        StartCoroutine(WaitAfterCollision());
        
        Vector3 rayOrigin = transform.position + transform.forward * 2f + transform.up * 1f;
        RaycastHit hit;
        
        if (Physics.Raycast(rayOrigin, transform.forward, out hit, 100f))
        {
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
        }
        Debug.DrawRay(rayOrigin, transform.forward * 100f, Color.red);
    }

    private IEnumerator WaitAfterCollision()
    {
        botCTP.isWaitingAfterCollision = true;
        yield return new WaitForSeconds(collisionWaitTime);
        botCTP.isWaitingAfterCollision = false;
    }
    private void PlayCrashSound()
    {
        if(crashSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(crashSound);
        }
    }
}
