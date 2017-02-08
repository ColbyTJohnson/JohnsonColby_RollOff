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

	private DeathCollider deathCollider;


	// Use this for initialization
	void Start () {

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

	}

	public void SetPlayerTwoScore (int score) {

		playerTwoScore = score;

	}

}
