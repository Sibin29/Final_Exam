using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Objects
{
    scoreObject,
    lives
}

public class GameManager : MonoBehaviour
{
    // Single Reference Static Variables
    public static GameManager Instance { get; private set;}

    // Score Variables
    public int Score = 0;

    // Lives Variable
    public int Lives = 3;

    // Snake Variables
    public Rigidbody2D snakeRigidbody;

    // Collision Variables
    public int collisionCounter = 0;

    // WinScoreVariable
    public int WinScore;

    // Level Variable
    public int Level;

    // Unity Function
    private void Awake()
    {
        // Ensure that there is only one instance of GameManager
        if(Instance == null)
        {
            Instance = this;
            // Intermediate Unity Tip and Trick
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        //ResetGame();
        Debug.Log("Game Started");
        RestartGame();
    }
    private void Update()
    {
        //Adding an option to manually restarting the game
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    public void HandleFoodCollision(string colliderObject)
    {
        Debug.Log("Collision Detected");
        collisionCounter++;
        Debug.Log("Collision Counter: " + collisionCounter);
        if (colliderObject == "Food")
        {
            Score++;
            UIManager.Instance.UpdateScore(Objects.scoreObject, Score);
            if(Score == WinScore)
            {
            // Player wins!
            // Display a win message!
            Debug.Log("Player Wins!");
            UIManager.Instance.DisplayWinMessage();
            // Stop!
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }       
        // Game Lose condition
        if ((collisionCounter == 15 && Score<WinScore) || Lives == 0)
        {
            //Player loses!
            // Display a lose message!
            Debug.Log("Player Loses!");
            UIManager.Instance.DisplayLoseMessage();
            // Stop!
            StopGame();
        }
    }

public void HandleBombCollision(string colliderObject)
{
   if (colliderObject == "Bomb")
    {
        Lives--;
        UIManager.Instance.UpdateScore(Objects.lives, Lives);
    }

// Game Lose condition
    if (Lives == 0)
    {
        //Player loses!
        // Display a lose message!
        Debug.Log("Player Loses!");
        UIManager.Instance.DisplayLoseMessage();
        // Stop!
        StopGame();
    }
}
    private void StopGame()
    {
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        Score = 0;
        Lives = 3;
        collisionCounter = 0;
        UIManager.Instance.UpdateScore(Objects.scoreObject, Score);
        UIManager.Instance.UpdateScore(Objects.lives, Lives);
        Debug.Log("Game Started");
    } 
}