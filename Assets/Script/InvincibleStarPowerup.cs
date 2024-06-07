using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the invincibility star power-up, including activation, duration tracking, and deactivation.
/// </summary>
public class InvincibleStarPowerup : MonoBehaviour
{
    [SerializeField] private Image starBar; // UI element to display power-up duration
    [SerializeField] private float powerupDuration = 5f; // Duration of the power-up
    [SerializeField] private GameObject player; // Reference to the player GameObject

    private float _starAmount = 0f;
    private bool _isPowerupActive = false;
    private float _currentPowerupTime;
    private PlayerCollision _status;

    private void Start()
    {
        if (player != null)
        {
            _status = player.GetComponent<PlayerCollision>();
        }
    }

    private void Update()
    {
        if (_isPowerupActive)
        {
            _currentPowerupTime -= Time.deltaTime;
            starBar.fillAmount = _currentPowerupTime / powerupDuration;
            Debug.Log("Draining");

            if (_currentPowerupTime <= 0f)
            {
                Deactivate();
            }
        }
    }

    /// <summary>
    /// Activates the invincibility power-up, setting the duration and updating the UI.
    /// </summary>
    public void Invincible()
    {
        _starAmount = 100f;
        starBar.fillAmount = _starAmount;
        _currentPowerupTime = powerupDuration;
        _isPowerupActive = true;
        _status.Empowered();
        Debug.Log("Activated");
    }

    /// <summary>
    /// Handles trigger events with the player, activating the power-up and destroying the power-up object.
    /// </summary>
    /// <param name="collision">The Collider2D data associated with this trigger event.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invincible();
            Destroy(gameObject); // Destroy the power-up after it has been collected
        }
    }

    /// <summary>
    /// Deactivates the invincibility power-up and updates the player state.
    /// </summary>
    private void Deactivate()
    {
        _isPowerupActive = false;
        _status.Depowered();
    }
}
