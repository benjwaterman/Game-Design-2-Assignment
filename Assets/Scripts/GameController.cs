using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text scoreCounter;
    public Text levelClearedText;
    public Text levelTimeText;
    public GameObject levelClearedCover;
    public GameObject nextLevelButton;
    public GameObject replayLevelButton;
    public GameObject flag1;
    public GameObject flag2;
    public bool gameRunning = true;

    private PlayerFinish flag1Finish;
    private PlayerFinish flag2Finish;
    private AudioSource source;

    private float time;

	// Use this for initialization
	void Start ()
    {
        flag1Finish = flag1.GetComponent<PlayerFinish>();
        flag2Finish = flag2.GetComponent<PlayerFinish>();
        source = GetComponent<AudioSource>();
        levelClearedCover.SetActive(false);
        levelTimeText.enabled = false;
        levelClearedText.enabled = false;
        nextLevelButton.SetActive(false);
        replayLevelButton.SetActive(false);
}
	
	// Update is called once per frame
	void Update () 
	{
        if(gameRunning)
        time += Time.deltaTime;
        scoreCounter.text = "Time: " + Math.Round(time, 2);

        if (Input.GetKeyDown("r"))
		{
            GameOver.EndGame();
        }

		if(Input.GetKeyDown("t"))
		{
			if(PlayerMovement.currentPlayer == 1)
				PlayerMovement.currentPlayer = 2;
			else
				PlayerMovement.currentPlayer = 1;
		}

        if (flag1Finish.playerFinished && flag2Finish.playerFinished) //level cleared
        {
            Time.timeScale = 0;

            levelTimeText.enabled = true;
            levelClearedText.enabled = true;
            levelClearedCover.SetActive(true);
            nextLevelButton.SetActive(true);
            replayLevelButton.SetActive(true);
            gameRunning = false;
            levelTimeText.text = Math.Round(time, 2).ToString();
        }
    }

    public void LoadNextLevel()
    {
        flag1Finish.playerFinished = false;
        flag2Finish.playerFinished = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    public void LoadThisLevel()
    {
        flag1Finish.playerFinished = false;
        flag2Finish.playerFinished = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void playSound( AudioClip sound, float volume)
    {
        source.PlayOneShot(sound, volume);
    }
}
