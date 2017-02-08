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

public class PlayerTwoScore : MonoBehaviour {

	private GameManager gameManager;
	private Text playerTwoText;

	// Use this for initialization
	void Start () {

		gameManager = FindObjectOfType<GameManager>();

		playerTwoText = GetComponent<Text>();
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	public void UpdateScore () {

		int playerTwoScore = gameManager.GetPlayerTwoScore();

		Debug.Log ("player two score is " + playerTwoScore);

		playerTwoText.text = playerTwoScore.ToString();

		Debug.Log ("Scoreboard update called with " + gameManager.GetPlayerTwoScore() + " as the new score");

	}

}
