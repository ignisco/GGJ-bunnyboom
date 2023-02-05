using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentAttachToCrib : MonoBehaviour
{

    public static List<BoxCollider2D> babyCribList;
    private Vector3 originPosition;
    private BoxCollider2D parentCollider;

    public GameObject parentPrefab;
    
    private void Awake() 
    {
        // set origin position to be able to return if dropped outside of crib
        originPosition = transform.position;
        babyCribList = new List<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        parentCollider = GetComponent<BoxCollider2D>();
    }

    private void OnMouseUp() 
    {
        // check if inside a baby's crib
        
        foreach (var babyCrib in babyCribList)
        {
            if (babyCrib.IsTouching(parentCollider))
            {
                // spawn a new at the origin position;
                //Instantiate(parentPrefab, originPosition, Quaternion.identity);
                // TODO WORK in progress on instantiation, but currently ruins drag and drop


                // attach to crib
                Vector3 pos = babyCrib.gameObject.GetComponent<CribImageLogic>().attachParent(gameObject);

                transform.position = pos;
                //increase the z-value (move back) so new dragged images will go over --REMOVED
                //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                transform.SetParent(babyCrib.transform);

                return;
            }
        }

        // Return to original position if dropped outside
        transform.position = originPosition;
    }
}
