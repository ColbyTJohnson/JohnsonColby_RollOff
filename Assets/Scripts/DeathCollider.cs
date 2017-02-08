// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/07/2017

// Purpose: A script to identify the death collider

// -------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DeathCollider : MonoBehaviour {

	private GameManager gameManager;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {

		gameManager = FindObjectOfType<GameManager>();
		levelManager = FindObjectOfType<LevelManager>();
	
	}
	
	// Update is called once per frame
	void Update () {

		
	
	}

	void OnTriggerEnter (Collider other) {

		if (other.name == "Player1") {

//			Debug.Log ("Player1 loses");

			int curScore = gameManager.GetPlayerTwoScore();

//			Debug.Log ("CurScore = " + curScore);

			curScore++;

//			Debug.Log ("New Score updated to " + curScore);

			gameManager.SetPlayerTwoScore(curScore);

//			Debug.Log ("Scoreboard called");

		} else if (other.name == "Player2") {

			int curScore = gameManager.GetPlayerOneScore();

			curScore++;

			gameManager.SetPlayerOneScore(curScore);

		}

		Debug.Log ("Collision Update Finished");

		int curScoreOne = gameManager.GetPlayerOneScore();
		int curScoreTwo = gameManager.GetPlayerTwoScore();

		if ((curScoreOne < 4) && (curScoreTwo < 4)) {

			gameManager.ResetRound();

		} else if (curScoreOne >= 4) {

			levelManager.LoadLevel ("04a_Player1Wins");

		} else if (curScoreTwo >= 4) {

			levelManager.LoadLevel ("04b_Player2Wins");

		}

	}

}
