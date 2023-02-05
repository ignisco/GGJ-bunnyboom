using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySpawner : MonoBehaviour
{
    public static List<BoxCollider2D> babyCribList = new List<BoxCollider2D>();

    public GameObject babyPrefab;
    public float timeBetweenStart = 4;
    public float timeBetween = 4;
    public int maxChildCount = 4;
    public int numberSpawned = 0;
    private float timer = 0;

    public float babySpeed;
    public float babySpeedStart = 0.04f;


    private void Start()
    {
        timeBetween = timeBetweenStart;
        babySpeed = babySpeedStart;
        numberSpawned = 0;
    }


    // Update is called once per frame
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && babyCribList.Count < maxChildCount)
        {
            timer = timeBetween;
            var baby = Instantiate(babyPrefab, transform.position, Quaternion.identity);
            // Set its speed based (which is based on number of points)
            baby.GetComponent<BabyMovement>().speed = babySpeed;

            numberSpawned += 1;
            // Speed up level
            float levelMultiplier = (GameManager.gameManager.activeScorePointer + 1) * 0.1f;
            timeBetween = timeBetweenStart / (1 + (numberSpawned / 3) * levelMultiplier);
            babySpeed = babySpeedStart * (1 + (numberSpawned / 3) * levelMultiplier);
        }
    }
}
