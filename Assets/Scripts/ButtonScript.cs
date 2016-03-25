using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
    public Sprite buttonDownSprite;
    public Sprite buttonUpSprite;

    private SpriteRenderer sRenderer;
    public bool activated = false;

    // Use this for initialization
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        if(buttonUpSprite == null)
            buttonUpSprite = sRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            sRenderer.sprite = buttonDownSprite;
        }

        else
            sRenderer.sprite = buttonUpSprite;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            activated = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            activated = false;
        }
    }
}
