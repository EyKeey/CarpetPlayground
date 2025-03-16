using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHit : MonoBehaviour
{
    [SerializeField] public float minHitForce = 200f;
    [SerializeField] public float maxHitForce = 1000f;
    [SerializeField] public float speedFactor = 10f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();

            if (ballRb != null)
            {
                float carSpeed = rb.velocity.magnitude;

                float hitForce = Mathf.Clamp(carSpeed * speedFactor, minHitForce, maxHitForce);

                Vector3 hitDirection = (collision.transform.position - transform.position).normalized;
                ballRb.AddForce(hitDirection * hitForce, ForceMode.Impulse);

            }

        }
        else
        {
            Debug.Log("BallHit script is attached to a gameobject that is not tagged as Ball"); 
        }
    }
}
