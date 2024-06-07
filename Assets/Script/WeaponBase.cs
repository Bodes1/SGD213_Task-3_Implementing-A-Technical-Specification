using UnityEngine;

/// <summary>
/// Abstract base class for all weapon types. Handles common weapon functionalities
/// and provides a framework for specific weapon behaviors.
/// </summary>
public abstract class WeaponBase : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField]
    protected float fireDelay = 0.5f;

    [SerializeField]
    protected GameObject bullet;

    [SerializeField]
    protected int initialAmmo = 0; // Initial ammo count

    protected int currentAmmo; // Current ammo count

    [SerializeField]
    private const int maxAmmo = 5; // Max ammo count

    public GameObject Bullet
    {
        get { return bullet; }
        set { bullet = value; }
    }

    [Header("References")]
    [SerializeField]
    protected Transform bulletSpawnPoint;

    [SerializeField]
    protected AmmoUIManager ammoUIManager; // Reference to the Ammo UI Manager

    public Transform BulletSpawnPoint
    {
        get { return bulletSpawnPoint; }
        set { bulletSpawnPoint = value; }
    }

    protected float lastFiredTime = 0f;

    protected virtual void Start()
    {
        currentAmmo = initialAmmo; // Initialize current ammo
        ammoUIManager.ResetAmmo(); // Initialize UI with full ammo
    }

    /// <summary>
    /// Abstract method to handle the shooting mechanism. Each derived class must implement its own shooting behavior.
    /// Should account for the fire delay to control shooting frequency.
    /// </summary>
    public abstract void Shoot();

    /// <summary>
    /// Method to consume ammo and update the UI. Returns true if ammo was successfully used, false if out of ammo.
    /// </summary>
    protected bool ConsumeAmmo()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
            ammoUIManager.UseAmmo();
            return true;
        }
        else
        {
            Debug.Log("Out of ammo!");
            return false;
        }
    }

    /// <summary>
    /// Method to reload ammo and update the UI.
    /// </summary>
    public void ReloadAmmo()
    {
        currentAmmo = Mathf.Clamp(currentAmmo + initialAmmo, 0, maxAmmo);
        ammoUIManager.ResetAmmo(); // Reset the UI with the new ammo count
    }

    /// <summary>
    /// Method to add ammo from a pickup and update the UI.
    /// </summary>
    public void AddAmmo(int amount)
    {
        currentAmmo = Mathf.Clamp(currentAmmo + amount, 0, maxAmmo);
        ammoUIManager.UpdateAmmoUI(currentAmmo);
    }
}
