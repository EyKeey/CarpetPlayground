using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckpointTracker : MonoBehaviour
{
    [SerializeField] private Transform checkpointsParent;
    [SerializeField] private List<Transform> checkpoints;

    private int currentCheckpoint;
    private void Awake()
    {
        for (int i = 0; i < checkpointsParent.childCount; i++)
        {
            checkpoints.Add(checkpointsParent.GetChild(i));
            checkpoints[i].gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        currentCheckpoint = 0;
        UpdateCheckpoint();
    }

    private void UpdateCheckpoint()
    {
        checkpoints[currentCheckpoint].gameObject.SetActive(false);
        checkpoints[currentCheckpoint + 1].gameObject.SetActive(true);
        
        currentCheckpoint = (currentCheckpoint + 1) % checkpoints.Count;
        Debug.Log(currentCheckpoint);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            UpdateCheckpoint();
        }
    }
}
