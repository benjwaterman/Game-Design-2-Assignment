using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public Rigidbody2D projectile;

	public int bulletSpeed = 1000;
    public int player;

    float localXScale;

    void Start () 
	{
        localXScale = projectile.transform.localScale.x;
	}

	void Update () 
	{
        if (PlayerMovement.currentPlayer == player)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Rigidbody2D clone;
                clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody2D;

                if (PlayerMovement.playerFacing == 0)
                {
                    clone.AddForce(new Vector2(bulletSpeed, 0)); //facing right
                    clone.transform.localScale = new Vector2(-localXScale, transform.localScale.y);
                    Destroy(clone, 1);
                }

                else if (PlayerMovement.playerFacing == 1)
                {
                    clone.AddForce(new Vector2(-bulletSpeed, 0)); //facing left
                    Destroy(clone, 1);
                }
            }
        }
	}
}
