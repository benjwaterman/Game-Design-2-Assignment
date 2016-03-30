using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public Rigidbody2D projectile;

	public int bulletSpeed = 1000;
    public int player;

    public AudioClip shootSound;

    private AudioSource source;

    float localXScale;

    void Start () 
	{
        localXScale = projectile.transform.localScale.x;
        source = GetComponent<AudioSource>();
	}

	void Update () 
	{
        if (PlayerMovement.currentPlayer == player)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Rigidbody2D clone;
                clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody2D;
                source.PlayOneShot(shootSound, 0.5f);

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
