using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributed : MonoBehaviour
{
    public enum FaceAttributes
    {
        Plain,
        Creep,
        Tronder,
    }

    public int FaceAttributesCount = System.Enum.GetValues(typeof(FaceAttributes)).Length;

    public enum HeadAttributes
    {
        Plain, Koss, Three, TopHat
    }

    public int HeadAttributesCount = System.Enum.GetValues(typeof(HeadAttributes)).Length;

    public enum BodyAttributes
    {
        Plain,
        Carrot,
        Chain,
        Angel,
    }

    public int BodyAttributesCount = System.Enum.GetValues(typeof(BodyAttributes)).Length;

    public FaceAttributes face;
    public HeadAttributes head;
    public BodyAttributes body;

    public SpriteRenderer faceSprite;
    public SpriteRenderer headSprite;
    public SpriteRenderer bodySprite;

    public Sprite[] faceSpriteArray;
    public Sprite[] headSpriteArray;
    public Sprite[] bodySpriteArray;

    // Start is called before the first frame update
    void Start()
    {
        face = (FaceAttributes)Random.Range(0, FaceAttributesCount);
        head = (HeadAttributes)Random.Range(0, HeadAttributesCount);
        body = (BodyAttributes)Random.Range(0, BodyAttributesCount);

        faceSprite = this.transform.Find("Face").GetComponent<SpriteRenderer>();
        headSprite = this.transform.Find("Head").GetComponent<SpriteRenderer>();
        bodySprite = this.transform.Find("Body").GetComponent<SpriteRenderer>();

        faceSpriteArray = Resources.LoadAll<Sprite>("Bunny face");
        headSpriteArray = Resources.LoadAll<Sprite>("Bunny heads");
        bodySpriteArray = Resources.LoadAll<Sprite>("Bunny body");

        faceSprite.sprite = faceSpriteArray[(int)face];
        headSprite.sprite = headSpriteArray[(int)head];
        bodySprite.sprite = bodySpriteArray[(int)body];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
