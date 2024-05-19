using UnityEngine;

public class spinAttack : MonoBehaviour
{
    private Collider2D attackCollider;
    public int damage = 10;

    private void Start()
    {
        attackCollider = GetComponent<Collider2D>();
        attackCollider.enabled = false; 
    }

    public void Attack()
    {
        attackCollider.enabled = true;
    }

    public void StopAttack()
    {
        attackCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyStats enemy = other.GetComponent<EnemyStats>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
