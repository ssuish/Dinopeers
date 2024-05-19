using UnityEngine;
using System.Collections;

public class EnemyDMG : MonoBehaviour
{
    private Collider2D attackCollider;
    public int damage = 10;
    public float attackDuration = 0.5f;

    private void Start()
    {
        attackCollider = GetComponent<Collider2D>();
        attackCollider.enabled = false; // Ensure the collider is initially disabled
    }

    public void Attack()
    {
        StartCoroutine(PerformAttack());
    }

    private IEnumerator PerformAttack()
    {
        attackCollider.enabled = true;
        yield return new WaitForSeconds(attackDuration);
        attackCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision Detected with: " + other.name); // Debugging

        if (other.CompareTag("Enemy"))
        {
            EnemyStats enemy = other.GetComponent<EnemyStats>();

            if (enemy != null)
            {
                Debug.Log("Enemy Hit: " + other.name); // Debugging
                enemy.TakeDamage(damage);
            }
        }
    }
}