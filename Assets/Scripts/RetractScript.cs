using UnityEngine;
using System.Collections;

public class RetractScript : MonoBehaviour {

    public GameObject input;
    public bool buttonLever = true; //false means lever
    public bool onlyOnce = true;
    public bool reduceScale = false;
    public float speed = 0.04f;

    private ButtonScript buttonScript;
    private LeverScript leverScript;
    private Vector3 startPos;
    private Vector3 startScale;
    private Vector3 moveTo;

    private bool forward = true; //which direction raft is moving in
    private bool moving = false;

    // Use this for initialization
    void Start ()
    {
        buttonScript = input.GetComponent<ButtonScript>();
        leverScript = input.GetComponent<LeverScript>();

        startPos = transform.position;
        startScale = transform.localScale;

        if (transform.childCount > 0)
            moveTo = this.gameObject.transform.FindChild("TargetPos").position; 
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (moving && onlyOnce)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTo, speed);
            if (reduceScale)
                transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }

        else if (!moving && onlyOnce)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed);
            if(reduceScale)
                transform.localScale = startScale;
        }

        else if (moving && !onlyOnce)
        {
            if (transform.position == moveTo)
                forward = false;

            else if (transform.position == moveTo)
                forward = true;

            if (forward)
                transform.position = Vector3.MoveTowards(transform.position, moveTo, speed);

            else if (!forward)
                transform.position = Vector3.MoveTowards(transform.position, startPos, speed);
        }

        if (buttonLever) //for button
        {
            if (buttonScript.activated)
                moving = true;
            else
                moving = false;
        }

        else if (!buttonLever) //for lever
        {
            if (leverScript.activated)
                moving = true;
            else
                moving = false;
        }
    }
}
