using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController_EndGameAndRestart : MonoBehaviour {

	public GameObject player;
	public Text gameOverText;
	public Text restartInstructionText;

	private bool ifGameOver;

	// Use this for initialization
	void Start () {
		ifGameOver = false; 
		gameOverText.enabled = false;
		restartInstructionText.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape) == true) {
			Application.Quit ();
		}

		if (ifGameOver == false) {
			if (isPlayerOutsideOfMap() == true) {
				activateGameOver ();
			}
		} else {
			if (Input.anyKeyDown == true) {
				restartActualScene ();
			}
		}
	}

	void activateGameOver () {
		ifGameOver = true;
		gameOverText.enabled = true;
		restartInstructionText.enabled = true;
	}

	bool isPlayerOutsideOfMap () {
		return player.GetComponent<Transform> ().position.y < -5;
	}

	void restartActualScene () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}