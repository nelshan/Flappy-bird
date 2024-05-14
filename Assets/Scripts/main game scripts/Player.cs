using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    public float gravity = -6.8f;
    public float strength = 4f;

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    [SerializeField]
    private AudioClip birdFlapClip;

    private AudioSource audioSource; // Reference to AudioSource component.

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>(); // Get AudioSource component.
        if (audioSource == null)
        {
            // If AudioSource component not found, add one dynamically.
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = birdFlapClip; // Assign the AudioClip to the AudioSource.
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpriteAnimation), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
                PlayFlapSound(); // Call function to play the flap sound.
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                direction = Vector3.up * strength;
                PlayFlapSound(); // Call function to play the flap sound.
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void PlayFlapSound()
    {
        // Check if audio clip and audio source are assigned.
        if (birdFlapClip != null && audioSource != null)
        {
            // Play the flap sound.
            audioSource.PlayOneShot(birdFlapClip);
        }
    }

    private void SpriteAnimation()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (other.gameObject.CompareTag("Score"))
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}


