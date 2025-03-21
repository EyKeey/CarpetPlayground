using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
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
