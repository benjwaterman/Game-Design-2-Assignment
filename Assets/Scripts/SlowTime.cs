using UnityEngine;
using System.Collections;

public class SlowTime : MonoBehaviour 
{
	[SerializeField]
	private float _timeScale = 1;

	private Rigidbody2D rb;
	private Vector2 tempForce;
	private Vector2 oldForce;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		tempForce = new Vector2(0,0);
		oldForce = new Vector2(0,0);
		//GetComponent<Rigidbody2D>().angularVelocity;
	}
	void Update()
	{
		if (Input.GetButtonDown("Fire2"))
		{
			//oldForce = rb.velocity;
		}

		if (Input.GetButton("Fire2"))
		{
			tempForce = rb.velocity / 2;
			rb.velocity = tempForce;
			rb.gravityScale = .5f;
		}

		if (Input.GetButtonUp ("Fire2"))
		{
			//rb.velocity = oldForce;
			rb.gravityScale = 1.0f;
		}
	}

	void FixedUpdate()
	{

	}
}
