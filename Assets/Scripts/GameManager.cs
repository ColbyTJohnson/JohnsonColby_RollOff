// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/08/2017

// Credit: fafase - http://answers.unity3d.com/questions/879246/how-to-wait-for-coroutine-to-finish.html

// Purpose: A script to manage the current match

// -------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int playerOneScore = 0;
	public int playerTwoScore = 0;

	private Vector3 playerOneInit = new Vector3 (-8, -6, 0);
	private Vector3 playerTwoInit = new Vector3 (8, -6, 0);

	private PlayerOneScore scoreOne;
	private PlayerTwoScore scoreTwo;

	private PlayerControl playerOneControl;
	private PlayerControl playerTwoControl;
	private PlayerMovement playerOneMove;
	private PlayerMovement playerTwoMove;

	private Countdown countdown;

	public GameObject playerOneObject;
	public GameObject playerTwoObject;

	// Use this for initialization
	void Start () {

		playerOneScore = 0;
		playerTwoScore = 0;

		scoreOne = FindObjectOfType<PlayerOneScore>();
		scoreTwo = FindObjectOfType<PlayerTwoScore>();

		playerOneControl = playerOneObject.GetComponent<PlayerControl>();
		playerTwoControl = playerTwoObject.GetComponent<PlayerControl>();

		playerOneMove = playerOneObject.GetComponent<PlayerMovement>();
		playerTwoMove = playerTwoObject.GetComponent<PlayerMovement>();

		SetPlayerOneScore (playerOneScore);
		SetPlayerTwoScore (playerTwoScore);

		countdown = FindObjectOfType<Countdown>();

		ResetRound();

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

//		Debug.Log ("GameManager new score = " + score);

		scoreOne.UpdateScore();

//		Debug.Log ("Player One Score updated in gamemanager");

	}

	public void SetPlayerTwoScore (int score) {

		playerTwoScore = score;

//		Debug.Log ("GameManager new score = " + score);

		scoreTwo.UpdateScore();

//		Debug.Log ("Player Two Score updated in gamemanager");

	}

	public void ResetRound () {

		Debug.Log ("Reset Round called");

		playerOneControl.enabled = false;
		playerTwoControl.enabled = false;

		playerOneObject.GetComponent<Rigidbody>().isKinematic = true;
		playerTwoObject.GetComponent<Rigidbody>().isKinematic = true;

		Debug.Log ("Player movement disabled");

		playerOneObject.transform.position = playerOneInit;
		playerTwoObject.transform.position = playerTwoInit;

	    StartCoroutine("RunCountdownCoroutine");

		Debug.Log ("Countdown finished");


	}

	IEnumerator RunCountdownCoroutine () {

		countdown.StartCoroutine("RunCountdown");

		yield return new WaitForSeconds (3.0f);

		playerOneControl.enabled = true;
		playerTwoControl.enabled = true;

		playerOneObject.GetComponent<Rigidbody>().isKinematic = false;
		playerTwoObject.GetComponent<Rigidbody>().isKinematic = false;

		Debug.Log ("Player movement enabled");

	}

}
