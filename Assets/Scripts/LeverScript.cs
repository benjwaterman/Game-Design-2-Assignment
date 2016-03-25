using UnityEngine;


public class LeverScript : MonoBehaviour {

    public bool activated = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            activated = !activated;
            invertSprite();
        }
    }

    void invertSprite()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
