using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Text playerHealthText; 
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

        int currentHearts = Mathf.CeilToInt((float)currentHealth / (maxHealth / 8));

        string healthText = "Hearts: " + currentHearts + "\n";
    
        int currentHeartHealth = currentHealth % (maxHealth / 8);
        healthText += "Current Heart HP: " + currentHeartHealth + "/" + (maxHealth / 8);

        playerHealthText.text = healthText;
    }



    void Die()
    {
        Debug.Log("Game Over");
        Destroy(gameObject); 
    }
}
