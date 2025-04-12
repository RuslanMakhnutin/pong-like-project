using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreOne, scoreTwo; // Create variables score for Player 1 and Player 2
    public TextMeshProUGUI scoreText;

    public GameObject ballPrefab; // Variable of ball prefab
    private GameObject currentBall; // Variable of ball on game space

    public void Start()
    {
        SpawnBall(Vector2.zero);
        UpdateScore();
    }

    public void SpawnBall(Vector2 spawnPos)
    {
        if (currentBall != null) // If ball is exist, destroy it
        {
            Destroy(currentBall); // Destroy existing ball
        }

        currentBall = Instantiate(ballPrefab, spawnPos, Quaternion.identity); // Spawn ball
    }

    public void UpdateScore()
    {
        scoreText.text = scoreOne + ":" + scoreTwo;
    }

    public void WinCheck()
    {
        if (scoreOne >= 25)
        {
            Time.timeScale = 0;
            scoreText.text = "Player 1 - WIN!";
        } 
        
        else if (scoreTwo >= 25)
        {
            Time.timeScale = 0;
            scoreText.text = "Player 2 - WIN!";
        }
    }
    
}
