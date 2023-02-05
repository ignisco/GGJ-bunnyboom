using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{

    Vector3 mousePositionOffset;

    private AudioSource pickAudio;

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void Start()
    {
        pickAudio = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        pickAudio.Play();
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();

    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }
}
