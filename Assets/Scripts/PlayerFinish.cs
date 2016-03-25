using UnityEngine;
using System.Collections;

public class PlayerFinish : MonoBehaviour {

    public bool playerFinished;

	// Use this for initialization
	void Start ()
    {
        playerFinished = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
            playerFinished = true;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
            playerFinished = false;
    }
}
