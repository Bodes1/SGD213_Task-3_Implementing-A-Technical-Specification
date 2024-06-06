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