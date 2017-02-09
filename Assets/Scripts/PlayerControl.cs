// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/07/2017

// Credit: AddTorque - Unity Official Tutorials

// Credit: Unity Standard Assets - Ball.cs

// Purpose: A script to manage Player control

// -------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	private PlayerMovement playerMovement;

	private Vector3 move;
	private bool jump;

	// Use this for initialization
	void Start () {

		playerMovement = GetComponent<PlayerMovement>();

	}
	
	// Update is called once per frame
	void Update () {

		if (this.tag == "Player1") {

			if (Input.GetKeyDown(KeyCode.A)) {

				move = (Vector3.left).normalized;

			} else if (Input.GetKeyDown(KeyCode.D)) {

				move = (Vector3.right).normalized;

			} else if (Input.GetKeyDown(KeyCode.W)) {

				jump = true;

			}

		} else if (this.tag == "Player2") {

			if (Input.GetKeyDown(KeyCode.J)) {

				move = (Vector3.left).normalized;

			} else if (Input.GetKeyDown(KeyCode.L)) {

				move = (Vector3.right).normalized;

			} else if (Input.GetKeyDown(KeyCode.I)) {

				jump = true;

			}

		}
	
	}

	void FixedUpdate () {

		playerMovement.Move (move, jump);
		jump = false;

	}
}
