// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/13/2017

// Purpose: A script to manage the powerups

// -------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	[Range(0f,100f)] [SerializeField] private float moveSpeed = 5.0f;

	[SerializeField] private string subTypeName = "UnknownPickup";

	[Range(0.3f, 5f)] [SerializeField] private float flashDelay = 0.5f;

	[SerializeField] AudioClip pickupSound;

	private Renderer renderer;

	// Use this for initialization
	void Start () {
	
		// Name the collider the subTypeName so we know what the pickup does
		GetComponent<Collider>().name = subTypeName;

		renderer = GetComponent<Renderer>();
	
		// Save memory
		Destroy (gameObject, 5f);
		
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position += transform.up * Time.deltaTime * moveSpeed;

		if(Time.fixedTime % flashDelay < .2) {
		
			renderer.enabled = false;
		
		} else {
		
			renderer.enabled = true;
		}
		
	}
	
	void OnTriggerEnter (Collider other) {
	
		if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2") {
		
			// Play the destroy sound upon being shot
			GetComponent<AudioSource>().PlayOneShot(pickupSound);
			
			// Destroy the enemy
			StartDestroy(pickupSound.length);
		
		}
	
	}
	
	void StartDestroy (float timeDelay) {
		
		// Disable the renderer and collider so that they are no longer visible/active
		GetComponent<Renderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
		
		// Start the delayed destroy
		Destroy (gameObject, timeDelay);
		
	}

}
