// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/15/2017

// Purpose: A script to identify the death collider

// -------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DeathCollider : MonoBehaviour {

	private GameManager gameManager;
	private LevelManager levelManager;

	public GameObject playerOneDeath;
	public GameObject playerTwoDeath;

	// Use this for initialization
	void Start () {

		gameManager = FindObjectOfType<GameManager>();
		levelManager = FindObjectOfType<LevelManager>();
	
	}
	
	// Update is called once per frame
	void Update () {

		
	
	}

	void OnTriggerEnter (Collider other) {

		if (other.tag == "Player1") {

			if (this.name == "Death") {

				Instantiate (playerOneDeath, other.transform.position, Quaternion.identity);

			} else if (this.name == "Death (1)") {

				Instantiate (playerOneDeath, other.transform.position, Quaternion.Euler (0f, 0f, -90f));

			} else if (this.name == "Death (2)") {

				Instantiate (playerOneDeath, other.transform.position, Quaternion.Euler (0f, 0f, 90f));

			}

//			Debug.Log ("Player1 loses");

			int curScore = gameManager.GetPlayerTwoScore();

//			Debug.Log ("CurScore = " + curScore);

			curScore++;

//			Debug.Log ("New Score updated to " + curScore);

			gameManager.SetPlayerTwoScore(curScore);

//			Debug.Log ("Scoreboard called");

			UpdateScore ();

		} else if (other.tag == "Player2") {

			if (this.name == "Death") {

				Instantiate (playerTwoDeath, other.transform.position, Quaternion.identity);

			} else if (this.name == "Death (1)") {

				Instantiate (playerTwoDeath, other.transform.position, Quaternion.Euler (0f, 0f, -90f));

			} else if (this.name == "Death (2)") {

				Instantiate (playerTwoDeath, other.transform.position, Quaternion.Euler (0f, 0f, 90f));

			}

			int curScore = gameManager.GetPlayerOneScore();

			curScore++;

			gameManager.SetPlayerOneScore(curScore);


			UpdateScore ();

		}

	}

	void UpdateScore () {

		Debug.Log ("Collision Update Finished");

		int curScoreOne = gameManager.GetPlayerOneScore ();
		int curScoreTwo = gameManager.GetPlayerTwoScore ();

		Debug.Log ("Score updated");

		if ((curScoreOne < 4) && (curScoreTwo < 4)) {

			gameManager.ResetRound ();

		} else if (curScoreOne >= 4) {

			levelManager.LoadLevel ("05a_Player1Wins");

		} else if (curScoreTwo >= 4) {

			levelManager.LoadLevel ("05b_Player2Wins");

		}

	}

}
