using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwareness : MonoBehaviour
{
    public Transform player;
    public float awarenessRadius = 10f;
    public float EnemySpeed = 0.1f;

    void Start()
    {

    }

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < awarenessRadius)
        {

            Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, EnemySpeed * Time.deltaTime);

            // Move towards the player
            transform.position += transform.forward * EnemySpeed * Time.deltaTime;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
{
    // Check if the colliding object is the player
    if (other.transform == player)
    {
        Debug.Log("Enemy collided with the player");
    }
}
}