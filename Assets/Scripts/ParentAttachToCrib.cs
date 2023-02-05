using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentAttachToCrib : MonoBehaviour
{

    private Vector3 originPosition;
    private BoxCollider2D parentCollider;

    public GameObject parentPrefab;
    
    private void Awake() 
    {
        // set origin position to be able to return if dropped outside of crib
        originPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        parentCollider = GetComponent<BoxCollider2D>();
    }

    private void OnMouseUp() 
    {
        // check if inside a baby's crib
        
        foreach (var babyCrib in BabySpawner.babyCribList)
        {
            if (babyCrib.IsTouching(parentCollider))
            {
                // spawn a new at the origin position;
                //Instantiate(parentPrefab, originPosition, Quaternion.identity);
                // TODO WORK in progress on instantiation, but currently ruins drag and drop


                // attach to crib
                Vector3 pos = babyCrib.gameObject.GetComponent<CribImageLogic>().attachParent(gameObject);

                transform.position = new Vector3(pos.x, pos.y, transform.position.z);
                transform.SetParent(babyCrib.transform);

                ParentSpawner.ParentSpawnerObject.GenerateParent(originPosition.x);
                return;
            }
        }

        // Return to original position if dropped outside
        transform.position = originPosition;
    }
}
