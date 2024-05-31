using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IHealth : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;
    private float healthAmount = 100f;

    private void Update()
    {
        // Reloads the scene when health hits zero
        if (healthAmount <= 0)
        {
            // Fine trun later
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    // Gets damage and updates the health bar
    public void Damage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }
}