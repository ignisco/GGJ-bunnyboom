using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour
{
    public int level;

    Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ClickHandling);
    }

    void ClickHandling()
    {
        // reset baby crib list
        BabySpawner.babyCribList = new List<BoxCollider2D>();

        GameManager.gameManager.LoadScene(level);
    }


}
