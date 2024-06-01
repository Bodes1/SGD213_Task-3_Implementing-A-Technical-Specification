using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvincibleStarPowerup : MonoBehaviour
{
    // Variables to help say how long it has and such
    [SerializeField]
    private Image starBar;
    private float starAmount = 0f;
    private bool isPowerupActive = false;
    private float currentPowerupTime;
    [SerializeField]
    private float powerupDuration = 5f;

    // Update is called once per frame
    void Update()
    {
        // If active starts draining powerup
        if (isPowerupActive == true)
        {
            currentPowerupTime -= Time.deltaTime;
            starBar.fillAmount = currentPowerupTime / powerupDuration;
            Debug.Log("Draining");

            if (currentPowerupTime <= 0f) 
            {
                Deactivate();
            }
        }
    }

    // Actives powerup
    public void Invincible()
    {
        starAmount = 100f;
        starBar.fillAmount = starAmount;
        currentPowerupTime = powerupDuration;
        isPowerupActive = true;
        Debug.Log("Actives");
    }

    private void Deactivate()
    {
        isPowerupActive = false;
    }
}
