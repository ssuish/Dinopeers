using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Image healthBar;   
    public int maxHealth = 800;
    private int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
        UpdatePlayerHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdatePlayerHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdatePlayerHealthUI()
    {
        healthBar.fillAmount = (float)currentHealth / maxHealth;
    }

    void Die()
    {
        Debug.Log("Game Over");
        Destroy(gameObject);
    }
}
