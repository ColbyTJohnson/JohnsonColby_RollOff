// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/07/2017

// Credit: Learn to Code By Making Games - Ben Tristem

// Purpose: A script to identify the death collider

// -------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DeathCollider : MonoBehaviour {

	private GameManager gameManager;

	// Use this for initialization
	void Start () {

		gameManager = FindObjectOfType<GameManager>();
	
	}
	
	// Update is called once per frame
	void Update () {

		
	
	}

	void OnTriggerEnter (Collider other) {

		if (other.name == "Player1") {

			Debug.Log ("Player1 loses");

			int curScore = gameManager.GetPlayerTwoScore();

			Debug.Log ("CurScore = " + curScore);

			curScore++;

			Debug.Log ("New Score updated to " + curScore);

			gameManager.SetPlayerTwoScore(curScore);

			Debug.Log ("Scoreboard called");

		} else if (other.name == "Player2") {

			int curScore = gameManager.GetPlayerOneScore();

			int newScore = curScore++;

			gameManager.SetPlayerOneScore(newScore);

		}

	}

}
