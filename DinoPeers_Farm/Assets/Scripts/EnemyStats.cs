using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    private float health = 50;

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
        Debug.Log("Damage Taken: " + damage); // Debugging
        Health -= damage;
    }

    private void Defeated()
    {
        Debug.Log("Enemy Defeated"); // Debugging
        Destroy(gameObject);
    }
}
