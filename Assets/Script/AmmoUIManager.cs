using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUIManager : MonoBehaviour
{
    public List<Image> ammoBars; // List of Image elements representing ammo bars
    private int currentAmmo;

    void Start()
    {
        currentAmmo = 0; // Initialize with zero ammo
        UpdateAmmoUI(currentAmmo); // Initialize UI with the current ammo count
    }

    // Call this method to use one ammo
    public void UseAmmo()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
            ammoBars[currentAmmo].enabled = false; // Hide the ammo bar
        }
    }

    // Call this method to reset ammo
    public void ResetAmmo()
    {
        currentAmmo = ammoBars.Count;
        foreach (Image bar in ammoBars)
        {
            bar.enabled = true; // Show all ammo bars
        }
    }

    // Call this method to update the UI with the current ammo count
    public void UpdateAmmoUI(int ammoCount)
    {
        currentAmmo = ammoCount;
        for (int i = 0; i < ammoBars.Count; i++)
        {
            ammoBars[i].enabled = i < currentAmmo;
        }
    }
}
