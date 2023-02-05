using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnhanceText : MonoBehaviour
{

    private TextMeshPro text;

    private float time;
    private Vector3 originPosition;

    private void Start()
    {
        text = GetComponent<TextMeshPro>();
        originPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.position = originPosition + new Vector3(0, 0.2f * Mathf.Sin(time * 10));
    }
}
