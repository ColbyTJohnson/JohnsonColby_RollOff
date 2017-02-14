// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/07/2017

// Purpose: A script to identify player one

// -------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class PlayerOne : MonoBehaviour {

	public AudioClip[] hits;

	public GameObject redCol;
	public GameObject blueCol;

	public bool speedOn;
	public bool instaOn;

	[SerializeField] GameObject speedParticles;
	[SerializeField] GameObject instaParticles;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {

		Vector3 offset = new Vector3 (transform.position.x, (transform.position.y - 1f), (transform.position.z - 1f));

		if (speedOn) {

			Instantiate (speedParticles, offset, Quaternion.identity);

		} else if (instaOn) {

			Instantiate (instaParticles, offset, Quaternion.identity);

		}
	
	}

	void OnTriggerEnter (Collider other) {

		Rigidbody rigidbody = GetComponentInParent<Rigidbody>();

		PlayerMovement playerMove = GetComponentInParent<PlayerMovement>();

		audioSource = GetComponentInParent<AudioSource>();

		if (other.tag == "Player2") {

			float random = Random.value;

			if (random > 0.75) {

				audioSource.PlayOneShot(hits[0]);

			} else if (random < 0.25) {

				audioSource.PlayOneShot(hits[1]);

			} else if (random <= 0.25 && random > 0.5) {

				audioSource.PlayOneShot(hits[2]);

			} else {

				audioSource.PlayOneShot(hits[3]);

			}

			Instantiate (redCol, transform.position, Quaternion.identity);
			Instantiate (blueCol, other.transform.position, Quaternion.identity);

			Debug.Log ("Audio played");

		}

		if (other.tag == "Powerup") {

			if (other.name == "Speed") {

//				Debug.Log (this.name + " collided with speed powerup");

				speedOn = true;

				playerMove.movePower = playerMove.movePower * 2;
				playerMove.torquePower = playerMove.torquePower * 2;

			} else if (other.name == "Mass") {

//				Debug.Log (this.name + " collided with mass powerup");

				rigidbody.mass = rigidbody.mass * 3;

			} else if (other.name == "Instakill") {

//				Debug.Log (this.name + " collided with mass powerup");

				instaOn = true;

				playerMove.movePower = playerMove.movePower * 6;
				playerMove.torquePower = playerMove.torquePower * 6;
				playerMove.maxAngularVelocity = playerMove.maxAngularVelocity * 5;

				rigidbody.mass = rigidbody.mass * 3;

			}

		}

	}

}
