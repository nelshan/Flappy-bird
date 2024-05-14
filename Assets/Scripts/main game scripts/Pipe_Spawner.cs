using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [Header("Prefab Settings")]
    public GameObject prefab; // Reference to the prefab of the pipe.
    
    [Header("Spawn Settings")]
    public float spawnRate = 1f; // Rate at which pipes will be spawned.
    public float minHeight = -1f; // Minimum height for spawning pipes.
    public float maxHeight = 1f; // Maximum height for spawning pipes.

    private void OnEnable()
    {
        StartSpawning(); // Start spawning pipes when this object is enabled.
    }

    private void OnDisable()
    {
        StopSpawning(); // Stop spawning pipes when this object is disabled.
    }

    private void StartSpawning()
    {
        // Invoke the Spawn method at regular intervals defined by spawnRate.
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void StopSpawning()
    {
        // Cancel the invoking of the Spawn method.
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        // Instantiate a new pipe GameObject at the spawner's position.
        GameObject newPipe = Instantiate(prefab, transform.position, Quaternion.identity);
        
        // Randomly adjust the height of the spawned pipe within the specified range.
        float randomHeight = Random.Range(minHeight, maxHeight);
        newPipe.transform.position += Vector3.up * randomHeight;
    }
}
