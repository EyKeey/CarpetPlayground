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

    [HideInInspector] public float targetSpeed;
    [HideInInspector] public float currentSpeed;
    [HideInInspector] public bool isWaitingAfterCollision;
    [HideInInspector] public bool isReversing;

    private Transform player;
    private Rigidbody rb;
    private Vector3 direction;

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
        }else if (isReversing)
        {
            targetSpeed = -carSpeed;
        }
        else
        {
            targetSpeed = carSpeed;
        }

        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.fixedDeltaTime);
        Vector3 velocity = transform.forward * currentSpeed;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }
    
}
