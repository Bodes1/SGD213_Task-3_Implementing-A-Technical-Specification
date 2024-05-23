using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the behaviour for the Health Interface. Used for both
/// Player and enemy objects.
/// </summary>
public interface IHealth
{
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
