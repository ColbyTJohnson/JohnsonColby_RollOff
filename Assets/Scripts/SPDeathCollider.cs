// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/15/2017

// Purpose: A script to identify the death collider in single player

// -------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class SPDeathCollider : MonoBehaviour {

	private SPGameManager gameManager;
	private LevelManager levelManager;

	public GameObject playerOneDeath;

	// Use this for initialization
	void Start () {

		gameManager = FindObjectOfType<SPGameManager>();
		levelManager = FindObjectOfType<LevelManager>();

	}
	
	// Update is called once per frame
	void Update () {

		

	}

	void OnTriggerEnter (Collider other) {

		if (other.tag == "Player") {

			if (this.name == "Death") {

				Instantiate (playerOneDeath, other.transform.position, Quaternion.identity);

				Debug.Log ("Player collided with bottom");

			} else if (this.name == "Death (1)") {

				Instantiate (playerOneDeath, other.transform.position, Quaternion.Euler (0f, 0f, -90f));

				Debug.Log ("Player collided with Left");

			} else if (this.name == "Death (2)") {

				Instantiate (playerOneDeath, other.transform.position, Quaternion.Euler (0f, 0f, 90f));

				Debug.Log ("Player collided with Right");

			}

			Debug.Log ("Collision done");

			gameManager.ResetPlayer();

		}

		// TODO create lives

	}

}
