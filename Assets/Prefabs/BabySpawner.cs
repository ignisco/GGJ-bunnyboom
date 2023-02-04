using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySpawner : MonoBehaviour
{

    public GameObject babyPrefab;
    public float timeBetween = 3;
    private float timer;

    private void Start()
    {
        timer = timeBetween;
    }

    // Update is called once per frame
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeBetween;
            Instantiate(babyPrefab, transform.position, Quaternion.identity);
        }
        
    }
}
