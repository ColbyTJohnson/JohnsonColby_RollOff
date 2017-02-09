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

	private Vector3 playerOneInit = new Vector3 (-8, -8, 0);
	private Vector3 playerTwoInit = new Vector3 (8, -8, 0);

	private PlayerOneScore scoreOne;
	private PlayerTwoScore scoreTwo;

	private PlayerControl playerOneControl;
	private PlayerControl playerTwoControl;
	private PlayerMovement playerOneMove;
	private PlayerMovement playerTwoMove;

	private Countdown countdown;

	private GameObject playerOneObject;
	private GameObject playerTwoObject;

	private Rigidbody playerOneRigidbody;
	private Rigidbody playerTwoRigidbody;

	// Use this for initialization
	void Start () {

		playerOneScore = 0;
		playerTwoScore = 0;

		Identify ();

		SetPlayerOneScore (playerOneScore);
		SetPlayerTwoScore (playerTwoScore);

		countdown = FindObjectOfType<Countdown>();

		ResetRound();

	}
	
	// Update is called once per frame
	void Update () {

		
	
	}

	void Identify () {

		playerOneObject = GameObject.FindGameObjectWithTag("Player1");
		playerTwoObject = GameObject.FindGameObjectWithTag("Player2");

		scoreOne = FindObjectOfType<PlayerOneScore> ();
		scoreTwo = FindObjectOfType<PlayerTwoScore> ();

		playerOneControl = playerOneObject.GetComponent<PlayerControl> ();
		playerTwoControl = playerTwoObject.GetComponent<PlayerControl> ();

		playerOneMove = playerOneObject.GetComponent<PlayerMovement> ();
		playerTwoMove = playerTwoObject.GetComponent<PlayerMovement> ();

		playerOneRigidbody = playerOneObject.GetComponent<Rigidbody>();
		playerTwoRigidbody = playerTwoObject.GetComponent<Rigidbody>();

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

//		Debug.Log ("Reset Round called");

		Destroy (playerOneObject);
		Destroy (playerTwoObject);

		Instantiate (playerOneObject, playerOneInit, Quaternion.identity);
		Instantiate (playerTwoObject, playerTwoInit, Quaternion.identity);

		Identify ();

		playerOneControl.enabled = false;
		playerTwoControl.enabled = false;

		playerOneRigidbody.isKinematic = true;
		playerTwoRigidbody.isKinematic = true;

		Debug.Log ("Player movement disabled");

//		playerOneObject.transform.position = playerOneInit;
//		playerTwoObject.transform.position = playerTwoInit;

	    StartCoroutine("RunCountdownCoroutine");

//		Debug.Log ("Countdown finished");


	}

	IEnumerator RunCountdownCoroutine () {

		countdown.StartCoroutine("RunCountdown");

		Debug.Log ("Countdown started");

		yield return new WaitForSeconds (3.0f);

		Debug.Log ("Wait finished");

		Identify ();

		playerOneControl.enabled = true;
		playerTwoControl.enabled = true;

		playerOneMove.enabled = true;
		playerTwoMove.enabled = true;

		playerOneRigidbody.isKinematic = false;
		playerTwoRigidbody.isKinematic = false;

		Debug.Log ("Player movement enabled");

	}

}
