using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {

	private float timeToExpire = 0.8f;
    public GameObject explosion;
    public AudioClip explosionSound;

    private GameController gController;
	
	// Use this for initialization
	void Start ()
    {
        gController = FindObjectOfType<GameController>();
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
            gController.playSound(explosionSound, 0.5f);
        }

        Destroy (gameObject);
	}
}
