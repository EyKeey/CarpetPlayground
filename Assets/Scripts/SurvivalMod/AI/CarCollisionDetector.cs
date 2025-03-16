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

    private void FixedUpdate()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position + transform.up * 2f, transform.forward, out hit, 20f))
        {
            if(!hit.collider.CompareTag("Player")){
                botCTP.isReversing = true;
            }
        }
        else
        {
            botCTP.isReversing = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            return;
        }

        botCTP.currentSpeed = 0;
        botCTP.targetSpeed = 0;
        rb.velocity = Vector3.zero;
        PlayCrashSound();
        StartCoroutine(WaitAfterCollision());

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        if(collision.gameObject.CompareTag("Bot"))
        {
            collision.gameObject.GetComponent<Bot>().TakeDamage(damage);
        }
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
