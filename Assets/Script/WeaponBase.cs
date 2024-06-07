using UnityEngine;

/// <summary>
/// Abstract base class for all weapon types. Handles common weapon functionalities
/// and provides a framework for specific weapon behaviors.
/// </summary>
public abstract class WeaponBase : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] protected float fireDelay = 1f;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected int initialAmmo = 0;

    protected int currentAmmo;
    private const int MaxAmmo = 5;

    /// <summary>
    /// Gets or sets the bullet prefab used by this weapon.
    /// </summary>
    public GameObject Bullet
    {
        get => bullet;
        set => bullet = value;
    }

    [Header("References")]
    [SerializeField] protected Transform bulletSpawnPoint;
    [SerializeField] protected AmmoUIManager ammoUIManager;

    /// <summary>
    /// Gets or sets the transform at which bullets will spawn.
    /// </summary>
    public Transform BulletSpawnPoint
    {
        get => bulletSpawnPoint;
        set => bulletSpawnPoint = value;
    }

    protected float lastFiredTime = 0f;

    /// <summary>
    /// Initializes the weapon's ammo and sets the last fired time to zero.
    /// </summary>
    protected virtual void Start()
    {
        InitializeAmmo();
    }

    /// <summary>
    /// Abstract method to handle the shooting mechanism. Each derived class must implement its own shooting behavior.
    /// </summary>
    public abstract void Shoot();

    /// <summary>
    /// Initializes ammo and updates the UI.
    /// </summary>
    public void InitializeAmmo()
    {
        currentAmmo = initialAmmo;
        ammoUIManager.UpdateAmmoUI(currentAmmo);
    }

    /// <summary>
    /// Consumes ammo and updates the UI. Returns true if ammo was successfully used, false if out of ammo.
    /// </summary>
    /// <returns>True if ammo was successfully used, false if out of ammo.</returns>
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
    /// Reloads ammo and updates the UI.
    /// </summary>
    public void ReloadAmmo()
    {
        currentAmmo = Mathf.Clamp(currentAmmo + initialAmmo, 0, MaxAmmo);
        ammoUIManager.UpdateAmmoUI(currentAmmo);
    }

    /// <summary>
    /// Adds ammo from a pickup and updates the UI.
    /// </summary>
    /// <param name="amount">The amount of ammo to add.</param>
    public void AddAmmo(int amount)
    {
        currentAmmo = Mathf.Clamp(currentAmmo + amount, 0, MaxAmmo);
        ammoUIManager.UpdateAmmoUI(currentAmmo);
    }
}
