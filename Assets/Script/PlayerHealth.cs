using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Manages the player's health, including taking damage, restoring health, and updating the health UI.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private float maxHealth = 100f;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = maxHealth; // Initialize the player's health to the maximum value
        healthBar.fillAmount = _currentHealth / maxHealth; // Initialize health bar
    }

    /// <summary>
    /// Restores the player's health by a specified amount.
    /// </summary>
    /// <param name="amount">The amount of health to restore.</param>
    public void RestoreHealth(float amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, maxHealth); // Increase health and clamp it between 0 and maxHealth
        healthBar.fillAmount = _currentHealth / maxHealth; // Update health bar
        Debug.Log($"Health Restored: {amount}. Current Health: {_currentHealth}");
    }

    /// <summary>
    /// Decreases the player's health by a specified amount and reloads the scene if health drops to zero.
    /// </summary>
    /// <param name="amount">The amount of damage to take.</param>
    public void TakeDamage(float amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - amount, 0, maxHealth); // Decrease health and clamp it between 0 and maxHealth
        healthBar.fillAmount = _currentHealth / maxHealth; // Update health bar
        Debug.Log($"Damage Taken: {amount}. Current Health: {_currentHealth}");

        // Reload the scene when health hits zero
        if (_currentHealth <= 0)
        {
            SceneManager.LoadScene("MainScene"); // Change scene name to load that scene
        }
    }

    /// <summary>
    /// Gets the current health of the player.
    /// </summary>
    /// <returns>The current health of the player.</returns>
    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    /// <summary>
    /// Gets the maximum health of the player.
    /// </summary>
    /// <returns>The maximum health of the player.</returns>
    public float GetMaxHealth()
    {
        return maxHealth;
    }
}
