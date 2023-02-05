using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CribImageLogic : MonoBehaviour
{
    private List<GameObject> attachedParents;
    public int numberOfParents = 2;
    private List<Transform> parentSpots;
    public float ascensionSpeed = 0.1f;

    private Animator anim;


    private void FixedUpdate()
    {
        if (anim.enabled == true)
        {
            // ascend
            transform.position = new Vector3(transform.position.x,
                transform.position.y + ascensionSpeed, transform.position.z);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        // Adding its own collider to the parent's list of colliders
        BabySpawner.babyCribList.Add(GetComponent<BoxCollider2D>());
        attachedParents = new List<GameObject>();

        //Adding transform of left and right photoframe as parent spots
        parentSpots = new List<Transform>();
        parentSpots.Add(transform.Find("PhotoFrame Left"));
        parentSpots.Add(transform.Find("PhotoFrame Right"));
    }

    public Vector3 attachParent(GameObject parent)
    {
        attachedParents.Add(parent);

        // When it has got all its N parents
        if (attachedParents.Count >= numberOfParents)
        {
            //Remove itself from the crib list so no other images can be attached
            BabySpawner.babyCribList.Remove(GetComponent<BoxCollider2D>());

            Debug.Log("Setting the animation");

            //Initiate rocket animation
            Debug.Log(anim.GetBool("Ascension"));
            anim.enabled = true;

            //Start co-routine for deletion after some time
            StartCoroutine(DeletionAfterFlying());
            

        }

        Vector3 nextParentPos = parentSpots[attachedParents.Count - 1].position;
        return nextParentPos;
        
    }


    IEnumerator DeletionAfterFlying()
    {

        // Doesn't really return, just weird syntax for waiting 5 seconds
        yield return new WaitForSeconds(5);

        Destroy(gameObject);

    }

}
