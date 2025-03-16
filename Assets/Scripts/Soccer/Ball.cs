using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [HideInInspector] public GameObject lastHitPlayer;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            lastHitPlayer = collision.gameObject;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Goal"))
        {
            if (lastHitPlayer != null)
            {
                Debug.Log("Goal scored by " + lastHitPlayer.name);
            }
        }
    }
}