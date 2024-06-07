using UnityEngine;
using UnityEngine.UI;

public class InvincibleStarPowerup : MonoBehaviour
{
    [SerializeField] private Image starBar;
    private float starAmount = 0f;
    private bool isPowerupActive = false;
    private float currentPowerupTime;
    [SerializeField] private float powerupDuration = 5f;

    private PlayerCollision status;
    [SerializeField] private GameObject player;

    private void Start()
    {
        if (player != null)
        {
            status = player.GetComponent<PlayerCollision>();
        }
    }

    void Update()
    {
        if (isPowerupActive)
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

    public void Invincible()
    {
        starAmount = 100f;
        starBar.fillAmount = starAmount;
        currentPowerupTime = powerupDuration;
        isPowerupActive = true;
        status.Empowered();
        Debug.Log("Activated");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invincible();
            Destroy(gameObject); // Destroy the power-up after it has been collected
        }
    }

    private void Deactivate()
    {
        isPowerupActive = false;
        status.Depowered();
    }
}
