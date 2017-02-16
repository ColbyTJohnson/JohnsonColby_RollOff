// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/15/2017

// Purpose: A script to identify the death collider in single player

// -------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class SPEndLevel : MonoBehaviour {

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {

		levelManager = FindObjectOfType<LevelManager>();

	}
	
	// Update is called once per frame
	void Update () {

		

	}

	void OnTriggerEnter (Collider other) {

		if (other.tag == "Player") {

			Debug.Log ("TRIGGERED");

			levelManager.LoadLevel ("05c_SPWin");

		}

	}

}
