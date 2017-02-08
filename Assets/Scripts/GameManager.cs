// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/07/2017

// Purpose: A script to manage the current match

// -------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private int playerOneScore = 0;
	private int playerTwoScore = 0;

	private PlayerOneScore scoreOne;
	private PlayerTwoScore scoreTwo;

	// Use this for initialization
	void Start () {

		scoreOne = FindObjectOfType<PlayerOneScore>();
		scoreTwo = FindObjectOfType<PlayerTwoScore>();

		SetPlayerOneScore (playerOneScore);
		SetPlayerTwoScore (playerTwoScore);

	}
	
	// Update is called once per frame
	void Update () {

		
	
	}

	public int GetPlayerOneScore () {

		return playerOneScore;

	}

	public int GetPlayerTwoScore () {

		return playerTwoScore;

	}

	public void SetPlayerOneScore (int score) {

		playerOneScore = score;

		Debug.Log ("GameManager new score = " + score);

		scoreOne.UpdateScore();

		Debug.Log ("Player One Score updated in gamemanager");

	}

	public void SetPlayerTwoScore (int score) {

		playerTwoScore = score;

		Debug.Log ("GameManager new score = " + score);

		scoreTwo.UpdateScore();

		Debug.Log ("Player Two Score updated in gamemanager");

	}

}
