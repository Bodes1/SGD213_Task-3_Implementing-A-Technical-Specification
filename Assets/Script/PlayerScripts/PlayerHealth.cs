using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private float maxHealth = 100f;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth; // Initialize the player's health to the maximum value
        healthBar.fillAmount = currentHealth / maxHealth; // Initialize health bar
    }

    public void RestoreHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth); // Increase health and clamp it between 0 and maxHealth
        healthBar.fillAmount = currentHealth / maxHealth; // Update health bar
        Debug.Log("Health Restored: " + amount + ". Current Health: " + currentHealth);
    }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth); // Decrease health and clamp it between 0 and maxHealth
        healthBar.fillAmount = currentHealth / maxHealth; // Update health bar
        Debug.Log("Damage Taken: " + amount + ". Current Health: " + currentHealth);

        // Reloads the scene when health hits zero
        if (currentHealth <= 0)
        {
            // Change scene name to load that scene
            SceneManager.LoadScene("MainScene");
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
}
