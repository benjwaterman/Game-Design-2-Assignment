using UnityEngine;
using System.Collections;

public class PowerUpFloat : MonoBehaviour 
{
	public float floatHeight;
	public float bobSpeed;

	private Vector3 initialPos;
	private Vector3 currentPos;

	private Rigidbody2D rb;

	private bool isAtMax = false;
	private bool movingUp = true;
	
	void Start () 
	{
		initialPos = transform.position;

		rb = GetComponent<Rigidbody2D>();
	}

	void Update () 
	{
		currentPos = transform.position;

		if (currentPos.y - initialPos.y >= floatHeight)
			movingUp = false;
		
		if (currentPos.y - initialPos.y <= -floatHeight)
			movingUp = true;

		if (movingUp)
			rb.velocity = (Vector3.up*bobSpeed);

		else if (!movingUp)
			rb.velocity = (Vector3.down*bobSpeed);
	}
}
