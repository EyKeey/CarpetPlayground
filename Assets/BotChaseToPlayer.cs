using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotChaseToPlayer : MonoBehaviour
{
    [SerializeField] private float turnSpeed;
    [SerializeField] private float carSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxTurnAnglePerSecond;


    private Transform player;
    private Rigidbody rb;
    private float targetSpeed;
    private float currentSpeed;
    private Vector3 direction;
    private bool isWaitingAfterCollision = false;
    private float collisionWaitTime = 3f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        targetSpeed = carSpeed;
    }

    private void FixedUpdate()
    {
        if(isWaitingAfterCollision)
        {
            return;
        }

        direction = player.position - transform.position;
        direction.y = 0;

        HandleRotation();
        HandleMovement();
    }

    private void HandleRotation()
    {
        float maxTurnAngle = maxTurnAnglePerSecond * Time.fixedDeltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, Mathf.Deg2Rad * maxTurnAngle, 0f);
        Quaternion rotation = Quaternion.LookRotation(newDirection);
        rb.MoveRotation(rotation);
    }
    private void HandleMovement()
    {
        if (Vector3.Angle(transform.forward, direction) > 15)
        {
            targetSpeed = carSpeed * 0.6f;
        }
        else
        {
            targetSpeed = carSpeed;
        }

        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.fixedDeltaTime);
        Vector3 velocity = transform.forward * currentSpeed;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentSpeed = 0;
            targetSpeed = 0;
            rb.velocity = Vector3.zero;
            StartCoroutine(WaitAfterCollision());
        }
    }

    private IEnumerator WaitAfterCollision()
    {
        isWaitingAfterCollision = true;
        yield return new WaitForSeconds(collisionWaitTime);
        isWaitingAfterCollision = false;
    }
}
