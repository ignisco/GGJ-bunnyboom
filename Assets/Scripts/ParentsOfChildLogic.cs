using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParentsOfChildLogic : MonoBehaviour
{
    private List<GameObject> attachedParents;
    public int numberOfParents = 2;
    private List<Transform> parentSpots;
    public float ascensionSpeed = 0.1f;

    private Animator anim;

    public GameObject scorePrefab;


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

            //Initiate rocket animation (by enabling animator :P)
            anim.enabled = true;

            // Disable boxcollider so it can't trigger game over
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            //Show heart
            transform.Find("Heart").gameObject.SetActive(true);

            //Start co-routine for deletion after some time
            StartCoroutine(DeletionAfterFlying());

            StartCoroutine(DisplayScore());
            
        }

        Vector3 nextParentPos = parentSpots[attachedParents.Count - 1].position;
        return nextParentPos;
        
    }

    public int calculateScore()
    {

        Attributed childAttributes = gameObject.GetComponent<Attributed>();

        int faceMatchCount = 0;
        int headMatchCount = 0;
        int bodyMatchCount = 0;

        foreach (GameObject parent in attachedParents) {
            Attributed parentAttribute = parent.GetComponent<Attributed>();
            
            if (childAttributes.face == parentAttribute.face)
            {
                faceMatchCount++;
            }

            if (childAttributes.head == parentAttribute.head)
            {
                headMatchCount++;
            }

            if (childAttributes.body == parentAttribute.body)
            {
                bodyMatchCount++;
            }
        }

        return 100 * (int) (Mathf.Pow(faceMatchCount, 2f) + Mathf.Pow(headMatchCount, 2f) + Mathf.Pow(bodyMatchCount, 2f));
    }

    IEnumerator DeletionAfterFlying()
    {

        // Doesn't really return, just weird syntax for waiting 5 seconds
        yield return new WaitForSeconds(5);

        Destroy(gameObject);

    }

    IEnumerator DisplayScore()
    {
        GameObject scoreObject = Instantiate(scorePrefab, transform.position, Quaternion.identity);

        scoreObject.GetComponent<TextMeshPro>().text = calculateScore().ToString();

        // Doesn't really return, just weird syntax for waiting 5 seconds
        yield return new WaitForSeconds(1);

        Destroy(scoreObject);

    }

}
