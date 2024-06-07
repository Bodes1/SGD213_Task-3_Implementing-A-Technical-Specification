using UnityEngine;

/// <summary>
/// Implements a machine gun firing mechanism. This weapon fires bullets continuously at a
/// fixed rate defined by the fireDelay.
/// </summary>
public class WeaponPistol : WeaponBase
{
    /// <summary>
    /// Overrides the Shoot method to continuously fire bullets at a rate determined by fireDelay.
    /// Each bullet is instantiated only if enough time has passed since the last shot.
    /// </summary>
    public override void Shoot()
    {
        float currentTime = Time.time;

        if (currentTime - lastFiredTime > fireDelay)
        {
            // Check if there is ammo to shoot
            if (ConsumeAmmo())
            {
                // Instantiate the bullet at the specified spawn point with the weapon's current orientation.
                GameObject newBullet = Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);

                // Update the last fired time to the current time after shooting.
                lastFiredTime = currentTime;

                // Optionally log shooting action for debugging purposes (comment out if not needed).
                Debug.Log("Pistol shot fired at: " + Time.time);
            }
        }
    }
}
