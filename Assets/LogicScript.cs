using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public AudioSource gameOverSound;
    public AudioSource restartSound; // Add this at the top with your other fields

    private int highScore;

    void Start()
    {
        // Load high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = highScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();

        if (playerScore > highScore)
        {
            highScore = playerScore;
            highScoreText.text = highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }
    public void restartGame()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);

        if (gameOverSound != null)
        {
            gameOverSound.Play();
        }
        else
        {
            Debug.LogWarning("Restart sound not assigned in LogicScript.");
        }
    }
    public void LoadHomeScene()
    {
        SceneManager.LoadScene("Home");
    }
    private bool isMuted = false;

    public void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0f : 1f;
    }
    public void MuteAudio()
    {
        AudioListener.volume = 0;
    }
    public void OnAudio()
    {
        AudioListener.volume = 1;
    }

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject resumeMenu;
    public void pause()
    {
        pauseMenu.SetActive(true);
        resumeMenu.SetActive(true);
        Time.timeScale = 0;
    }
        public void Resume()
    {
        resumeMenu.SetActive(false);
        pauseMenu.SetActive(false);
           
        Time.timeScale = 1;
    }
}