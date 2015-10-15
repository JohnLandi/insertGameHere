using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject player;
	public GameObject respawnPoint;

	public ParticleSystem winningParticles;

	public Text hud;
	public Canvas gameOverUI;
    public int deathCounter;

	//The amount of ellapsed time
	private float time = 0;
	
	//Flag that control the state of the game
	private bool isRunning = false;

	// Use this for initialization
	void Start () {
		InitGame();
        deathCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (isRunning) {
			time += Time.deltaTime;
			hud.text = "You have died " + (int)deathCounter + " times. \t\t\t\t\t\t\t\t\t\t\t\t\t\tYour time is " + (int)time;
		} else {
			hud.text = "You have died " + (int)deathCounter + " times. \t\t\t\t\t\t\t\t\t\t\t\t\t\tYour time was " + time; 
		}

		if(Input.GetAxis("Restart")>0) {
			RespawnPlayer();
		}
	}

	public void RespawnPlayer() {
		player.gameObject.transform.position = respawnPoint.transform.position;
        deathCounter += 1;
	}

	public void InitGame() {
		time = 0;
		isRunning = true;

		gameOverUI.enabled = false;

		winningParticles.Stop();
		winningParticles.Clear();
		RespawnPlayer();

        deathCounter = 0;
	}

	public void Win() {
		isRunning = false;


		gameOverUI.enabled = true;
		winningParticles.Play();
	}
}
