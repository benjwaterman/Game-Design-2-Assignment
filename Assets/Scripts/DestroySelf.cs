using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {

	public float timeToExpire = 0.8f;
    public GameObject explosion;
	
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		Destroy (gameObject, timeToExpire);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
        if (this.tag == "Bullet")
        {
            Instantiate(explosion, new Vector3(this.transform.position.x, this.transform.position.y, -5.0f), this.transform.rotation);
        }
		Destroy (gameObject);
	}
}
