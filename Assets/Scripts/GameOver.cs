using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") 
		{
            EndGame();
		}
	}

    public static void EndGame()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
