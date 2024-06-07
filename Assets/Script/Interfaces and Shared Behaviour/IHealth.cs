using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public interface IHealth
{
    void RestoreHealth(float amount);
    void TakeDamage(float amount);
    float GetCurrentHealth();
    float GetMaxHealth();

}

