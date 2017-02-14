// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/07/2017

// Purpose: A script to identify player two

// -------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class PlayerTwo : MonoBehaviour {

	public bool speedOn = false;
	public bool instaOn = false;

	[SerializeField] GameObject speedParticles;
	[SerializeField] GameObject instaParticles;

	// Use this for initialization
	void Start () {

		
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 offset = new Vector3 (transform.position.x, (transform.position.y - 1f), (transform.position.z - 1f));

		if (speedOn == true) {

			Instantiate (speedParticles, offset, Quaternion.identity);

		} else if (instaOn == true) {

			Instantiate (instaParticles, offset, Quaternion.identity);

		}
	
	}

	void OnTriggerEnter (Collider other) {

		Rigidbody rigidbody = GetComponentInParent<Rigidbody>();

		PlayerMovement playerMove = GetComponentInParent<PlayerMovement>();

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