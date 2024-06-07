using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Interface for health management, providing methods for restoring health, taking damage,
/// and getting current and maximum health values.
/// </summary>
public interface IHealth
{
    /// <summary>
    /// Restores the health by a specified amount.
    /// </summary>
    /// <param name="amount">The amount of health to restore.</param>
    void RestoreHealth(float amount);

    /// <summary>
    /// Decreases the health by a specified amount.
    /// </summary>
    /// <param name="amount">The amount of damage to take.</param>
    void TakeDamage(float amount);

    /// <summary>
    /// Gets the current health.
    /// </summary>
    /// <returns>The current health value.</returns>
    float GetCurrentHealth();

    /// <summary>
    /// Gets the maximum health.
    /// </summary>
    /// <returns>The maximum health value.</returns>
    float GetMaxHealth();
}
