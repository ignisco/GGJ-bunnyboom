using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int[] highScores  = new int[3] {0, 0, 0};
    public int activeScorePointer = 0;
    public int tempScore;

    public static GameManager gameManager;

    void Awake() {
        // Make sure there is only one GameManager
        if (gameManager != null) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }
    }

    public void LoadScene(int level) {

        // Setting the active score count to the level

        activeScorePointer = level;
        tempScore = 0; // resetting temporary score counter
        SceneManager.LoadScene(level + 1); // because level 0 is menu
    }

    public void AddScore(int points)
    {
        tempScore += points;
    }


    // Called when Time's Up or Game Over to finalize the score
    public void FinalizeScore()
    {
        if (tempScore > highScores[activeScorePointer])
        {
            highScores[activeScorePointer] = tempScore;
        }

        tempScore = 0;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
