using UnityEngine;
using System.Collections;

public class AnimateFlag : MonoBehaviour {

    public Sprite flagSprite1;
    public Sprite flagSprite2;

    private SpriteRenderer sRenderer;
    private float totalTime = 0;
    private bool currentFlag = true;

    // Use this for initialization
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        if (flagSprite1 == null)
            flagSprite1 = sRenderer.sprite;
    }

    // Update is called once per frame
    void Update ()
    {
        totalTime += Time.deltaTime;
        if (totalTime >= 0.8)
        {
            totalTime = 0;

            if (currentFlag)
            {
                sRenderer.sprite = flagSprite1;
                currentFlag = false;
            }

            else if (!currentFlag)
            {
                sRenderer.sprite = flagSprite2;
                currentFlag = true;
            }
        }
    }
}
