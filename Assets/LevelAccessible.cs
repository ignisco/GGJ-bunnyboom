using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAccessible : MonoBehaviour
{

    public int levelToCheck = 1;
    public int scoreTreshold = 1000;

    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(GameManager.gameManager.highScores[0]);

        if (GameManager.gameManager.highScores[levelToCheck - 1] >= scoreTreshold)
        {
            button.SetActive(true);
            gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
