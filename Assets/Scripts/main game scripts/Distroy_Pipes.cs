using UnityEngine;

public class Distroy_Pipes : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f; // Speed at which the pipes move horizontally.

    private float leftEdge; // X-coordinate of the left edge of the screen.

    private void Start()
    {
        CalculateLeftEdge(); // Calculate the left edge of the screen.
    }

    private void Update()
    {
        MovePipes(); // Move the pipes horizontally.
        CheckDestroyCondition(); // Check if the pipes should be destroyed.
    }

    private void CalculateLeftEdge()
    {
        // Calculate the x-coordinate of the left edge of the screen in world space.
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void MovePipes()
    {
        // Move the pipes to the left based on their speed and the passage of time.
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void CheckDestroyCondition()
    {
        // Check if the pipes have moved beyond the left edge of the screen.
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject); // Destroy the pipes GameObject.
        }
    }
}
