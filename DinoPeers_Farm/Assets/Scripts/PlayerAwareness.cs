using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwareness : MonoBehaviour
{
    public Transform player;
    public float awarenessRadius = 5f;
    public float enemySpeed = 1.5f;
    public List<Transform> riceCrops;  
    private Transform nearestRiceCrop;
    private bool playerInAwarenessRadius = false;
    private bool isAttacking;

    void Start()
    {
        // finds the nearest rice crop
        if (riceCrops != null && riceCrops.Count > 0)
        {
            nearestRiceCrop = FindNearestRiceCrop();
        }
    }

    void Update()
    {
        // finds the nearest rice crop
        if (riceCrops != null && riceCrops.Count > 0)
        {
            nearestRiceCrop = FindNearestRiceCrop();
        }

        // Check if the enemy is not attacking
        if (!isAttacking) 
        {
            // Check if the player is within the awareness radius
            if (Vector3.Distance(player.position, transform.position) < awarenessRadius)
            {
                playerInAwarenessRadius = true;
            }
            else
            {
                playerInAwarenessRadius = false;
            }

            if (playerInAwarenessRadius)
            {
                MoveTowards(player);
            }
            else if (nearestRiceCrop != null)
            {
                MoveTowards(nearestRiceCrop);
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
    private Transform FindNearestRiceCrop()
    {
        Transform nearest = null;
        float minDistance = float.MaxValue;

        // Find the nearest rice crop
        foreach (Transform crop in riceCrops)
        {
            float distance = Vector3.Distance(transform.position, crop.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = crop;
            }
        }

        return nearest;
    }

    void OnTriggerEnter2D(Collider2D other)
{
    // Check if the colliding object is the player
    if (other.transform == player)
    {
        Debug.Log("Enemy is attacking!");
        isAttacking = true;
    }
    // Check if the colliding object is a rice crop
    else if (other.gameObject.CompareTag("RiceCrop"))
    {
        Debug.Log("Enemy collided with a rice crop!");
        isAttacking = true;
    }
}

void OnTriggerExit2D(Collider2D other)
{
    // Check if the object that stopped colliding is the player
    if (other.transform == player)
    {
        Debug.Log("Enemy stopped attacking!");
        isAttacking = false;
    }
    // Check if the object that stopped colliding is a rice crop
    else if (other.gameObject.CompareTag("RiceCrop"))
    {
        Debug.Log("Enemy stopped colliding with a rice crop!");
        isAttacking = false; 
    }
}
}