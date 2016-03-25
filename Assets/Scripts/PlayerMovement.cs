using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public static int playerFacing = 0; //0 = right 1 = left
    public static int currentPlayer = 1; //should only be 1 or 2

    public int player;
    public bool enableFloating = false;

	private int horForce = 7;
	private int jumpForce = 500;
	private int maxJumps = 1;
	private int currentJumps = 0;

	private float xIn;

	private Vector2 xMovement = new Vector2 (0, 0);
	private Vector2 yMovement = new Vector2 (0, 0);
	private Vector3 theScale;

	private Rigidbody2D rb;

	//private ParticleSystem smokeParticle;

	public float floatHeight;
	public float liftForce;
	public float damping;
    private float localXScale;

    private Vector3 raycastPoint;
	
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
        //if (transform.childCount > 0)
        //    smokeParticle = GetComponentInChildren<ParticleSystem> (); //gets particle system
        localXScale = transform.localScale.x;

        if (transform.childCount > 0)
            raycastPoint = this.gameObject.transform.FindChild("RaycastPoint").position;
    }

	void Update () 
	{
		if (currentPlayer == player)
		{
            xIn = Input.GetAxis ("Horizontal");
			xMovement = new Vector2 (xIn*horForce, rb.velocity.y);
            if (xIn != 0)
                rb.velocity = xMovement;

			if(Input.GetButtonDown("Jump") && currentJumps < maxJumps)
			{
				yMovement = new Vector2 (rb.velocity.x, jumpForce);
				rb.velocity = new Vector2 (rb.velocity.x, 0);
				rb.AddForce(yMovement);
				currentJumps++;
			}

			if (xIn > 0)
                playerFacing = 0;
			if (xIn < 0)
                playerFacing = 1;

			//if (currentJumps == 1)
			//{
			//	//smokeParticle.startColor = new Color(0,0,1,1);
			//	smokeParticle.startLifetime = 0.35f;
			//	smokeParticle.startSize = 0.8f;
			//}

			//if (currentJumps == 2)
			//{
			//	//smokeParticle.startColor = new Color(0,0,0.5f,1);
			//	smokeParticle.startLifetime = 0.3f;
			//	smokeParticle.startSize = 0.6f;
			//}

            if (playerFacing == 1)
            {
                transform.localScale = new Vector2(-localXScale, transform.localScale.y);
            }

            else if (playerFacing == 0)
            {
                transform.localScale = new Vector2(localXScale, transform.localScale.y);
            }
        }
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Floor")
		{
			currentJumps = 0;
		}
	}

	void FixedUpdate ()
	{
        if (enableFloating)
        {
            RaycastHit2D hit = Physics2D.Raycast(raycastPoint, Vector2.down);
            if (hit.collider != null)
            {
                float distance = Mathf.Abs(hit.point.y - transform.position.y);
                float heightError = floatHeight + Random.value / 2 - distance;
                float force = liftForce * heightError - rb.velocity.y * damping;

                if (force > 0)
                    rb.AddForce(Vector2.up * force);
            }
        }
	}
}
