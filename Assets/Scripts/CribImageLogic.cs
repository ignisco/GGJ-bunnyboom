using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CribImageLogic : MonoBehaviour
{
    private List<GameObject> attachedParents;
    public int numberOfParents = 2;
    private List<Transform> parentSpots;

    // Start is called before the first frame update
    void Start()
    {
        // Adding its own collider to the parent's list of colliders
        ParentAttachToCrib.babyCribList.Add(GetComponent<BoxCollider2D>());
        attachedParents = new List<GameObject>();

        //Adding transform of left and right photoframe as parent spots
        parentSpots = new List<Transform>();
        parentSpots.Add(transform.Find("PhotoFrame Left"));
        parentSpots.Add(transform.Find("PhotoFrame Right"));
    }

    public Vector3 attachParent(GameObject parent)
    {
        attachedParents.Add(parent);

        // Removing itself from the crib list when it has N parents
        if (attachedParents.Count >= numberOfParents)
        {
            ParentAttachToCrib.babyCribList.Remove(GetComponent<BoxCollider2D>());
        }

        Vector3 nextParentPos = parentSpots[attachedParents.Count - 1].position;
        return nextParentPos;
        
    }

}
