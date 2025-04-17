using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Level Variable
    public int level;

    // Load Level 1
    public void LoadLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Load Level 2
    public void LoadLevel2()
    {
        GameManager.Instance.Level = 2;
        GameManager.Instance.WinScore = 10;
        GameManager.Instance.Score = 0;
        GameManager.Instance.collisionCounter = 0;
        GameManager.Instance.Lives = 3;
        GameManager.Instance.RestartGame();
        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Load Level 3
    public void LoadLevel3()
    {
        GameManager.Instance.Level = 3;
        GameManager.Instance.WinScore = 15;
        GameManager.Instance.Score = 0;
        GameManager.Instance.collisionCounter = 0;
        GameManager.Instance.Lives = 3;
        GameManager.Instance.RestartGame();
        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Load Game Complete
    public void LoadGameComplete()
    {
        GameManager.Instance.Level = 1;
        GameManager.Instance.WinScore = 5;
        GameManager.Instance.Score = 0;
        GameManager.Instance.collisionCounter = 0;
        GameManager.Instance.Lives = 3;
        GameManager.Instance.RestartGame();
        // Load the next scene
        SceneManager.LoadScene(0);
    }

    public void PlayBtnClicked()
    {
        if (level < 1)
        {
        LoadLevel1();
        } else if (level == 1)
        {
        LoadLevel2();
        } else if (level == 2)
        {
        LoadLevel3();
        } else if (level == 3)
        {
        LoadGameComplete();
        }
    }
}
