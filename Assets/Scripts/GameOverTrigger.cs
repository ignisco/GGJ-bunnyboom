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

        }
    }
}