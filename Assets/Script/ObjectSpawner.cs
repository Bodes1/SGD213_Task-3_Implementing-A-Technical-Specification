using UnityEngine;

/// <summary>
/// Spawns objects repeatedly over time at random positions within the bounds of the attached renderer.
/// </summary>
public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] pickups; // Array of prefabs to spawn
    [SerializeField] private float spawnDelay = 2f; // Delay between each spawn

    private Renderer _pickupSpriteRenderer;

    /// <summary>
    /// Initializes the spawner by hiding its renderer and setting up repeated spawning.
    /// </summary>
    private void Start()
    {
        _pickupSpriteRenderer = GetComponent<Renderer>();
        if (_pickupSpriteRenderer != null)
        {
            // Hide the spawner's renderer to make it invisible
            _pickupSpriteRenderer.enabled = false;

            // Start the repeated spawning process
            InvokeRepeating(nameof(Spawn), spawnDelay, spawnDelay);
        }
        else
        {
            Debug.LogError("Renderer component not found, spawner will not function correctly.");
        }
    }

    /// <summary>
    /// Spawns an object at a random horizontal position within the bounds of the renderer.
    /// </summary>
    private void Spawn()
    {
        if (_pickupSpriteRenderer != null && pickups.Length > 0)
        {
            float x1 = transform.position.x - _pickupSpriteRenderer.bounds.size.x / 2;
            float x2 = transform.position.x + _pickupSpriteRenderer.bounds.size.x / 2;

            // Randomly pick a point within the bounds of the renderer to spawn the object
            Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

            // Randomly select a prefab from the array
            int randomIndex = Random.Range(0, pickups.Length);
            GameObject pickup = pickups[randomIndex];

            // Instantiate the selected prefab at the calculated spawn point
            Instantiate(pickup, spawnPoint, Quaternion.identity);
        }
    }
}
