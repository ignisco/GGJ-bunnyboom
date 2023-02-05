using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    private TextMeshPro text;
    public int time = 20;

    public GameObject gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        StartCoroutine(Tick());
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    IEnumerator Tick()
    {

        if (time > 0)
        {
            yield return new WaitForSeconds(1);
            time -= 1;

            if (time < 10)
            {
                text.text = "0:0" + time.ToString();
            }
            else
            {
                text.text = "0:" + time.ToString();
            }

            // If still enabled (not game over), keep ticking
            if (this.enabled)
            {
                StartCoroutine(Tick());
            }
        }

        else
        {

            // Time's up

            FindObjectOfType<BabySpawner>().enabled = false;

            gameOverText.GetComponent<TextMeshPro>().text = "TIME'S UP";
            gameOverText.SetActive(true);

            // disable all baby movement

            foreach (var script in FindObjectsOfType<BabyMovement>())
            {
                script.enabled = false;
            }

            // disable all conveyor belt movement
            foreach (var script in FindObjectsOfType<ConveyorAnimator>())
            {
                script.enabled = false;
            }

            // Add score to high score
            GameManager.gameManager.FinalizeScore();


            // Go back to menu

            yield return new WaitForSeconds(4);


            GameManager.gameManager.LoadMenu();


        }

    }
}
