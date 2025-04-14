using UnityEngine;

public class RespawnByTrigger : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerOneTrigger")) // If ball in Player 1 gates
        {
            gameManager.scoreTwo++; // Add score-point to Player 2
            //Debug.Log("A goal has been scored against player 1! Score " + gameManager.scoreOne + ":" + gameManager.scoreTwo);
            gameManager.UpdateScore();
            gameManager.WinCheck();
            gameManager.SpawnBall(Vector2.zero);
        }

        else if (collision.CompareTag("PlayerTwoTrigger")) // If ball in Player 2 gates
        {
            gameManager.scoreOne++; // Add score-point to Player 1
            //Debug.Log("A goal has been scored against player 2! Score " + gameManager.scoreOne + ":" + gameManager.scoreTwo);
            gameManager.UpdateScore();
            gameManager.WinCheck();
            gameManager.SpawnBall(Vector2.zero);
        }
    }
}
