using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverPopUp : MonoBehaviour
{
    // Sizes for fonts

    public float maxSize = 20;
    public float growthSpeed = 1;

    private TextMeshPro text;

    private void Start()
    {
        text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (text.fontSize < maxSize)
        {
            text.fontSize += Time.deltaTime * growthSpeed;
        }
    }
}
