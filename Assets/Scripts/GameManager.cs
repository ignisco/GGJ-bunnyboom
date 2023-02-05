using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int[] highScores;
    public int activeScorePointer;
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
        SceneManager.LoadScene("Play");
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
