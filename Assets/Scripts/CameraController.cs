using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;

    public float cameraSpeed = 1;

    private float currentCameraY;
    
	// Use this for initialization
	void Start ()
    {
        currentCameraY = transform.position.y;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerMovement.currentPlayer == 1)
        {
            SmoothCameraFollow(player1);
        }

        else if (PlayerMovement.currentPlayer == 2)
        {
            SmoothCameraFollow(player2);
        }
    }

    void SmoothCameraFollow(GameObject targetPlayer)
    {
        float step = cameraSpeed * Time.deltaTime;
        Vector3 targetPos = new Vector3(targetPlayer.transform.position.x, currentCameraY, -10);
        step *= Mathf.Abs((targetPlayer.transform.position.x - transform.position.x + 1) / 3);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
    }
}
