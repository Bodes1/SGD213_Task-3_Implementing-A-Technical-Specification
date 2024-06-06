using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Defines the behaviour for the Health Interface. Used for both
/// Player and enemy objects.
/// </summary>
public interface IHealth
{
<<<<<<< HEAD
    // Property for current health of game object.
    int CurrentHealth { get; }

    // Property to get the maximum allowed health for the game object.
    int MaxHealth { get; }

    /// <summary>
    /// Specify the amount of damage to take.
    /// </summary>
    /// <param name="damageAmount">The amount of damage to apply to the object.</param>
    void TakeDamage(int damageAmount);

    /// <summary>
    /// Specify the amount of damage to take.
    /// </summary>
    /// <param name="healAmount">The amount of healing to apply to the object.</param>
    void Heal(int healAmount);

    /// <summary>
    /// Determines whether object can receive healing or not.
    /// </summary>
    /// <returns>True if the object can receive health, otherwise false.</returns>
    bool canReceiveHeal();

    /// <summary>
    /// Behaviour for when the game object runs out of health, death event.
    /// </summary>
    void Die();
}
=======
    [SerializeField]
    private Image healthBar;
    private float healthAmount = 100f;

    private void Update()
    {
        // Reloads the scene when health hits zero
        if (healthAmount <= 0)
        {
            // Change scene name to load that scene
            SceneManager.LoadScene("Bodhi_Test_Scene");
        }
    }

    // Gets damage and updates the health bar
    public void Damage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }
}
>>>>>>> d968aaf6915b2736f309f0a920ad83a642ad6517
