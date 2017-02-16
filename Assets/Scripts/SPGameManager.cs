// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/07/2017

// Purpose: A script to manage the single player levels

// -------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class SPGameManager : MonoBehaviour {

	[SerializeField] Vector3 playerStart;

	private PlayerControl playerControl;
	private PlayerMovement playerMove;

	private Countdown countdown;

	private GameObject player;
	private Rigidbody playerRigidbody;
	private AudioSource playerAudioSource;
	private AudioSource playerMainAudio;
	private PlayerOne playerScript;

	// Use this for initialization
	void Start () {

		Identify();

		countdown = FindObjectOfType<Countdown>();

		ResetPlayer();

	}
	
	// Update is called once per frame
	void Update () {

		

	}

	void Identify () {

		player = GameObject.FindGameObjectWithTag("Player1");

		playerControl = player.GetComponent<PlayerControl> ();

		playerMove = player.GetComponent<PlayerMovement> ();

		playerRigidbody = player.GetComponent<Rigidbody>();

		playerScript = player.GetComponentInChildren<PlayerOne>();
		playerMainAudio = player.GetComponent<AudioSource>();
		playerAudioSource = player.GetComponentInChildren<AudioSource>();

	}

	public void ResetPlayer () {

		Debug.Log ("Reset Round called");

		Destroy (player);

		Debug.Log ("Player destroyed");

		Instantiate (player, playerStart, Quaternion.identity);

		Debug.Log ("Player created");

		Identify ();

		playerControl.enabled = false;
		playerMove.enabled = false;

		playerRigidbody.isKinematic = true;

//		Debug.Log ("Player movement disabled");

		StartCoroutine ("RunCountdownCoroutine");

	}

	IEnumerator RunCountdownCoroutine () {

		countdown.StartCoroutine("RunCountdown");

//		Debug.Log ("Countdown started");

		yield return new WaitForSeconds (5.0f);

//		Debug.Log ("Wait finished");

		Identify ();

		playerControl.enabled = true;

		playerMove.enabled = true;

		playerScript.enabled = true;
		playerAudioSource.enabled = true;
		playerMainAudio.enabled = true;

		playerRigidbody.isKinematic = false;

		playerRigidbody.mass = 1f;

		playerMove.movePower = 20f;
		playerMove.torquePower = 3f;
		playerMove.maxAngularVelocity = 25f;

		playerScript.speedOn = false;
		playerScript.instaOn = false;

		Debug.Log ("Player movement enabled");

	}

}
