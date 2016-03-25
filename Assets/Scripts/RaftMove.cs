using UnityEngine;
using System.Collections;
using System.Linq;

public class RaftMove : MonoBehaviour {

    public GameObject input;
    public bool buttonLever = true; //false means lever
    public bool andOr = true; //false means OR
    public float speed = 0.04f;

    private Vector3 moveTo;
    private Vector3 startPos;

    private ButtonScript buttonScript;
    private LeverScript leverScript;

    private bool forward = true; //which direction raft is moving in
    private bool moving = false;

    // Use this for initialization
    void Start ()
    {
        startPos = transform.position;
        if (transform.childCount > 0)
            moveTo = this.gameObject.transform.FindChild("TargetPos").position;

        buttonScript = input.GetComponent<ButtonScript>();
        leverScript = input.GetComponent<LeverScript>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (moving)
        {
            if (transform.position == moveTo)
                forward = false;

            else if (transform.position == startPos)
                forward = true;

            if (forward)
                transform.position = Vector3.MoveTowards(transform.position, moveTo, speed);

            else if (!forward)
                transform.position = Vector3.MoveTowards(transform.position, startPos, speed);
        }

        if (buttonLever)
        {
            if (buttonScript.activated)
                moving = true;
            else
                moving = false;
        }

        if (!buttonLever)
        {
            if (leverScript.activated)
                moving = true;
            else
                moving = false;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            coll.gameObject.transform.parent = this.transform;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.transform.parent = null;
        }
    }
}
