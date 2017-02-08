// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/07/2017

// Purpose: A script to manage the scoreboard

// -------------------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Score : MonoBehaviour {

	private GameManager gameManager;
	private Text playerOneText;
	private Text playerTwoText;

	// Use this for initialization
	void Start () {

		gameManager = FindObjectOfType<GameManager>();

		if (this.name == "Player 1 Score") {

			playerOneText = GetComponent<Text>();

		} else if (this.name == "Player 2 Score") {

			playerTwoText = GetComponent<Text>();

		}
	
	}
	
	// Update is called once per frame
	void Update () {

		UpdateScore ();
	
	}

	void UpdateScore () {

		if (this.name == "Player 1 Score") {

			playerOneText.text = gameManager.GetPlayerOneScore().ToString();

		} else if (this.name == "Player 2 Score") {

			playerTwoText.text = gameManager.GetPlayerTwoScore().ToString();

		}

	}

}
