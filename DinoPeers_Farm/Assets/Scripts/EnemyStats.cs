using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private float health = 10;

    public float Health
    {
        get { return health; }
        set
        {
            health = value;
            if (health <= 0)
            {
                Defeated();
            }
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    private void Defeated()
    {
        Destroy(gameObject);
    }
}
