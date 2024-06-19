using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public GameObject[] checkpoints; // Array to hold the checkpoints
    public float speed = 5f; // Speed of the enemy
    public float rotationSpeed = 5f; // Rotation speed of the enemy

    private int currentCheckpointIndex = 0; // Current checkpoint index
    private Transform targetCheckpoint; // Current target checkpoint transform

    void Start()
    {
        if (checkpoints.Length > 0)
        {
            targetCheckpoint = checkpoints[currentCheckpointIndex].transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetCheckpoint == null) return; // If no valid target checkpoint, do nothing

        MoveAndRotateTowardsCheckpoint();
    }

    private void MoveAndRotateTowardsCheckpoint()
    {
        // Get the direction to the current checkpoint
        Vector3 direction = (targetCheckpoint.position - transform.position).normalized;

        // Move towards the current checkpoint
        transform.position = Vector3.MoveTowards(transform.position, targetCheckpoint.position, speed * Time.deltaTime);

        // Rotate towards the checkpoint smoothly
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }

        // Check if the enemy has reached the checkpoint
        if ((transform.position - targetCheckpoint.position).sqrMagnitude < 0.01f)
        {
            // Move to the next checkpoint
            currentCheckpointIndex = (currentCheckpointIndex + 1) % checkpoints.Length;
            targetCheckpoint = checkpoints[currentCheckpointIndex].transform;
        }
    }
}
