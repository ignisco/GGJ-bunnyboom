using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentSpawner : MonoBehaviour
{
    
    public int parentCount;
    public GameObject parentPrefab;

    public static ParentSpawner ParentSpawnerObject;

    void Start()
    {
        ParentSpawnerObject = this;

        for (int i=0; i < parentCount; i++)
        {
            Instantiate(parentPrefab, transform.position + new Vector3(i * 2.5f, Random.Range(-0.1f, 0.1f), 0), Quaternion.identity);
        }
    }

    public void GenerateParent(float xPosition)
    {
        Vector3 pos = new Vector3(xPosition, transform.position.y + Random.Range(-0.1f, 0.1f), transform.position.z);
        Instantiate(parentPrefab, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
