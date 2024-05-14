using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public Player player;
    public Text scoreText;
    public Text GameOver_HightscoreText;
    public Text GameOver_CurrentscoreText;
    public Text onScreen_HightscoreText;
    public GameObject playButton;
    public GameObject exitButton; // Add reference to the exitButton GameObject.
    public GameObject gameOver;
    [SerializeField] private AudioClip birddieClip;
    [SerializeField] private AudioClip birdpointClip;
    [SerializeField] private AudioClip buttonclickClip;

    private int score;

    private AudioSource audioSource; // Reference to AudioSource component.

    public void Start()
    {
        GameOver_HightscoreText.text = "High Score: " + HightScore_save.GetHightScore_save().ToString();
        onScreen_HightscoreText.text = "High Score: " + HightScore_save.GetHightScore_save().ToString();

        audioSource = GetComponent<AudioSource>(); // Get AudioSource component.
        if (audioSource == null)
        {
            // If AudioSource component not found, add one dynamically.
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = birddieClip; // Assign the AudioClip to the AudioSource.
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        // Play button click sound.
        PlaySound(buttonclickClip);

        scoreText.gameObject.SetActive(true);
        onScreen_HightscoreText.gameObject.SetActive(true);

        score = 0;
        UpdateScoreText();

        playButton.SetActive(false);
        exitButton.SetActive(false); // Hide the exitButton when the game starts.
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        EnablePlayer();

        DestroyExistingPipes_outOfView();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        DisablePlayer();
    }

    public void GameOver()
    {
        scoreText.gameObject.SetActive(false);
        onScreen_HightscoreText.gameObject.SetActive(false);

        GameOver_CurrentscoreText.text = "Current Score: " + score;

        // Play the birddieClip sound.
        PlaySound(birddieClip);

        if (HightScore_save.SetNewHighScore(score))
        {
            int newHighScore = HightScore_save.GetHightScore_save();
            GameOver_HightscoreText.text = "High Score: " + newHighScore;
            onScreen_HightscoreText.text = "High Score: " + newHighScore;
        }

        gameOver.SetActive(true);
        playButton.SetActive(true);
        exitButton.SetActive(true); // Show the exitButton when the game is over.

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();

        // Play the birdpointClip sound when score increases.
        PlaySound(birdpointClip);
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    private void EnablePlayer()
    {
        player.enabled = true;
    }

    private void DisablePlayer()
    {
        player.enabled = false;
    }

    private void DestroyExistingPipes_outOfView()
    {
        Distroy_Pipes[] pipes = FindObjectsOfType<Distroy_Pipes>();
        foreach (Distroy_Pipes pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    // Method to quit the game when the exitButton is clicked.
    public void ExitGame()
    {
        Application.Quit();
    }
}
