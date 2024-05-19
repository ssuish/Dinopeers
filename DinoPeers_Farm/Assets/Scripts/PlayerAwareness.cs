using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwareness : MonoBehaviour
{
    public Transform player;
    public List<Transform> riceCrops;       
    public float detectionRadius = 1f;
    public float enemySpeed = 0.5f;

    void Start()
    {
        // Find all game objects with the "RiceCrop" tag
        GameObject[] riceCropObjects = GameObject.FindGameObjectsWithTag("RiceCrop");

        // Get the transform of each rice crop and add it to the list
        foreach (GameObject riceCropObject in riceCropObjects)
        {
            riceCrops.Add(riceCropObject.transform);
        }
    }

    void Update()
    {
        // Check if the player is within the detection radius
        if (Vector2.Distance(transform.position, player.position) < detectionRadius)
        {
            Debug.Log("Player is within detection radius");
            MoveTowards(player);
        }
        else 
        {
            // Check if any of the rice crops are within the detection radius
            foreach (Transform riceCrop in riceCrops)
            {
                if (Vector2.Distance(transform.position, riceCrop.position) < detectionRadius)
                {
                    Debug.Log("Rice crop is within detection radius");
                    MoveTowards(riceCrop);
                    break;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player entered the box collider
        if (other.transform == player)
        {
            Debug.Log("Player is being attacked");
        }
        else 
        {
            // Check if the rice crop entered the box collider
            foreach (Transform riceCrop in riceCrops)
            {
                if (other.transform == riceCrop)
                {
                    Debug.Log("Rice crop is being attacked");
                    break;
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // Check if the player is still in the box collider
        if (other.transform == player)
        {
            Debug.Log("Player is still being attacked");
        }
        else 
        {
            // Check if the rice crop is still in the box collider
            foreach (Transform riceCrop in riceCrops)
            {
                if (other.transform == riceCrop)
                {
                    Debug.Log("Rice crop is still being attacked");
                    break;
                }
            }
        }
    }

    private void MoveTowards(Transform target)
{
    // Calculate the direction towards the target
    Vector2 directionToTarget = (target.position - transform.position).normalized;

    // Move towards the target
    transform.position += new Vector3(directionToTarget.x, directionToTarget.y, 0) * enemySpeed * Time.deltaTime;
}
}