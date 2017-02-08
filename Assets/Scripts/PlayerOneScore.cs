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

public class PlayerOneScore : MonoBehaviour {

	private GameManager gameManager;
	private Text playerOneText;

	// Use this for initialization
	void Start () {

		gameManager = FindObjectOfType<GameManager>();

		playerOneText = GetComponent<Text>();
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	public void UpdateScore () {

		int playerOneScore = gameManager.GetPlayerOneScore();

//		Debug.Log ("player two score is " + playerOneScore);

		playerOneText.text = playerOneScore.ToString();

//		Debug.Log ("Scoreboard update called with " + gameManager.GetPlayerOneScore() + " as the new score");

	}

}
