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
    private AudioSource audio;

    public GameObject scorePrefab;
    Timer timer;


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
        timer = FindObjectOfType<Timer>();

        // Adding its own collider to the parent's list of colliders
        BabySpawner.babyCribList.Add(GetComponent<BoxCollider2D>());
        attachedParents = new List<GameObject>();

        //Adding transform of left and right photoframe as parent spots
        parentSpots = new List<Transform>();
        parentSpots.Add(transform.Find("PhotoFrame Left"));
        parentSpots.Add(transform.Find("PhotoFrame Right"));

        audio = GetComponent<AudioSource>();
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

            audio.Play();

            //Start co-routine for deletion after some time
            StartCoroutine(DeletionAfterFlying());

            StartCoroutine(StartFade(audio, 3, 0));

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

        return 100 * (int) (Mathf.Pow(faceMatchCount, 2f) + Mathf.Pow(headMatchCount, 2f) + Mathf.Pow(bodyMatchCount, 2f) + faceMatchCount + headMatchCount + bodyMatchCount);
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


        // Add score to Game Manager
        GameManager.gameManager.AddScore(calculateScore());

        // Add time to timer
        float timerIncrease = calculateScore() / 100;
        timer.time += (int)(timerIncrease / (1 + (GameManager.gameManager.tempScore / 1000) * 0.1f));

        // Display score
        scoreObject.GetComponent<TextMeshPro>().text = calculateScore().ToString();

        // Doesn't really return, just weird syntax for waiting 1 second
        yield return new WaitForSeconds(1);

        Destroy(scoreObject);

    }
    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

}
