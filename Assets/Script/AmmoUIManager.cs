using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUIManager : MonoBehaviour
{
    [SerializeField] private List<Image> ammoBars; // List of Image elements representing ammo bars
    private int _currentAmmo;

    private void Start()
    {
        _currentAmmo = 0; // Initialize with zero ammo
        UpdateAmmoUI(_currentAmmo); // Initialize UI with the current ammo count
    }

    /// <summary>
    /// Call this method to use one ammo.
    /// </summary>
    public void UseAmmo()
    {
        if (_currentAmmo > 0)
        {
            _currentAmmo--;
            ammoBars[_currentAmmo].enabled = false; // Hide the ammo bar
        }
    }

    /// <summary>
    /// Call this method to reset ammo.
    /// </summary>
    public void ResetAmmo()
    {
        _currentAmmo = ammoBars.Count;
        foreach (Image bar in ammoBars)
        {
            bar.enabled = true; // Show all ammo bars
        }
    }

    /// <summary>
    /// Call this method to update the UI with the current ammo count.
    /// </summary>
    /// <param name="ammoCount">The current ammo count.</param>
    public void UpdateAmmoUI(int ammoCount)
    {
        _currentAmmo = ammoCount;
        for (int i = 0; i < ammoBars.Count; i++)
        {
            ammoBars[i].enabled = i < _currentAmmo;
        }
    }
}
