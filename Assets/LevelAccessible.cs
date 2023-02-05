using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAccessible : MonoBehaviour
{

    public int levelToCheck = 0;
    public int scoreTreshold = 1000;

    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {

        if (GameManager.gameManager.highScores[levelToCheck] >= scoreTreshold)
        {
            button.SetActive(true);
            gameObject.SetActive(false);
        } else
        {
            Debug.Log(GameManager.gameManager.highScores[levelToCheck]);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
