using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get; private set;}

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI ScoreTextTitle;
    public TextMeshProUGUI LivesTextTitle;

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

    // Update the score and lives text
    public void UpdateScore(Objects obstacle, int value)
    {
        if(obstacle == Objects.scoreObject)
        {
            ScoreText.text = value.ToString() + " / " + GameManager.Instance.WinScore.ToString();
        }
        else if(obstacle == Objects.lives)
        {
            LivesText.text = value.ToString() + " / 3";
        }
    }

    // Display a win message
    public void DisplayWinMessage()
    {
        Debug.Log("You Win!");
    }

    // Display a lose message
    public void DisplayLoseMessage()
    {
        Debug.Log("You Lose!");
    }
}   
