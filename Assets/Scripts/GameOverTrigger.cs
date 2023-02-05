using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{

    public GameObject gameOverText;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Baby")
        {
            FindObjectOfType<BabySpawner>().enabled = false;
            gameOverText.SetActive(true);

            // disable timer

            FindObjectOfType<Timer>().enabled = false;

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

            StartCoroutine(BackToMenu());




        }
    }

    IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(4);
        GameManager.gameManager.LoadMenu();
    }
}
