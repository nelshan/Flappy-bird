using UnityEngine;

public class BackgroundImageMover : MonoBehaviour
{
    [Header("Settings")]
    public float backgroundAnimationSpeed = 0.1f; // Speed for the background animation.
    public float groundAnimationSpeed = 0.3f; // Speed for the ground animation.

    public GameObject backgroundObject; // Reference to the GameObject containing the background material.
    public GameObject groundObject; // Reference to the GameObject containing the ground material.

    private MeshRenderer backgroundMeshRenderer; // Reference to the MeshRenderer component of the background.
    private MeshRenderer groundMeshRenderer; // Reference to the MeshRenderer component of the ground.

    private void Awake()
    {
        InitializeComponents(); // Initialize the required components.
    }

    private void Update()
    {
        MoveBackgroundImage(); // Move the background image.
        MoveGroundImage(); // Move the ground image.
    }

    private void InitializeComponents()
    {
        // Get the MeshRenderer components attached to the background and ground GameObjects.
        backgroundMeshRenderer = backgroundObject.GetComponent<MeshRenderer>();
        groundMeshRenderer = groundObject.GetComponent<MeshRenderer>();
    }

    private void MoveBackgroundImage()
    {
        // Update the texture offset of the background material to move the background image.
        backgroundMeshRenderer.material.mainTextureOffset += new Vector2(backgroundAnimationSpeed * Time.deltaTime, 0);
    }

    private void MoveGroundImage()
    {
        // Update the texture offset of the ground material to move the ground image.
        groundMeshRenderer.material.mainTextureOffset += new Vector2(groundAnimationSpeed * Time.deltaTime, 0);
    }
}
