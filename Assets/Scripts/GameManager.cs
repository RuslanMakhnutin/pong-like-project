using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreOne, scoreTwo; // Create variables score for Player 1 and Player 2
    public int winScore = 10;
    public TextMeshProUGUI scoreText;

    public GameObject buttonRestart;
    public GameObject playerOne, playerTwo;
    public Vector2 posP1, posP2;

    public GameObject ballPrefab; // Variable of ball prefab
    private GameObject currentBall; // Variable of ball on game space

    public AudioClip winSound, restartSound;
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 0;
    }

    public void SpawnBall(Vector2 spawnPos)
    {
        if (currentBall != null) // If ball is exist, destroy it
        {
            Destroy(currentBall); // Destroy existing ball
        }

        currentBall = Instantiate(ballPrefab, spawnPos, Quaternion.identity); // Spawn ball
    }

    public void GameRestart() // Start or restart game
    {
        audioSource.PlayOneShot(restartSound);

        // Score equals zero
        scoreOne = 0;
        scoreTwo = 0;

        // Players go to start positions
        playerOne.transform.position = posP1;
        playerTwo.transform.position = posP2;

        SpawnBall(Vector2.zero);
        UpdateScore();
        Time.timeScale = 1;

        buttonRestart.SetActive(false);
    }

    public void UpdateScore() // Update score text
    {
        scoreText.text = scoreOne + ":" + scoreTwo;
    }

    public void WinCheck() // Chesking players score value
    {
        if (scoreOne >= winScore)
        {
            audioSource.PlayOneShot(winSound);
            Time.timeScale = 0; // Pause
            scoreText.text = "Player 1 - WIN!";
            buttonRestart.SetActive(true);
        }

        else if (scoreTwo >= winScore)
        {
            audioSource.PlayOneShot(winSound);
            Time.timeScale = 0; // Pause
            scoreText.text = "Player 2 - WIN!";
            buttonRestart.SetActive(true);
        }
    }


}
