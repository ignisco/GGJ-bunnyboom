using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorAnimator : MonoBehaviour
{

    public float intervalBetweenFrames = 0.1f;
    private SpriteRenderer spriteRenderer;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = intervalBetweenFrames;
    }

    // Update is called once per frame
    void Update()
    {
        // Just flipping the sprite on the y axis to simulate movement
        timer -= Time.deltaTime;
        if (timer <= 0) {
            timer = intervalBetweenFrames;
            spriteRenderer.flipY = !spriteRenderer.flipY;
        }
        
    }
}
