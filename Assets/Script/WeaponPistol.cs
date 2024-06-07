using UnityEngine;

/// <summary>
/// Implements the shooting mechanism for a pistol weapon. This class derives from WeaponBase
/// and provides the specific implementation for shooting a pistol.
/// </summary>
public class WeaponPistol : WeaponBase
{
    /// <summary>
    /// Shoots a bullet if the fire delay has passed and there is ammo available.
    /// </summary>
    public override void Shoot()
    {
        float currentTime = Time.time;

        if (currentTime - lastFiredTime > fireDelay)
        {
            if (ConsumeAmmo())
            {
                Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
                lastFiredTime = currentTime;
                Debug.Log("Pistol shot fired at: " + Time.time);
            }
        }
    }
}
