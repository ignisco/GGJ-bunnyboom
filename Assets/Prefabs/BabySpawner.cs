using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySpawner : MonoBehaviour
{
    public static List<BoxCollider2D> babyCribList = new List<BoxCollider2D>();

    public GameObject babyPrefab;
    public float timeBetween;
    public int maxChildCount = 4;
    private float timer = 0;
    

    // Update is called once per frame
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && babyCribList.Count < maxChildCount)
        {
            timer = timeBetween;
            Instantiate(babyPrefab, transform.position, Quaternion.identity);
        }
        
    }
}
