// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/13/2017

// Purpose: A script to manage the powerup generator

// -------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class PowerupGenerator : MonoBehaviour {

	[SerializeField] GameObject[] powerupTypes;

	[SerializeField] private Vector3 direction;

	private Vector3 initialPos;
	private Vector3 offset;
	private float moveTimer;
	[Range(0.1f,100f)] [SerializeField] private float moveSpeed = 1f;

	[SerializeField] private float spawnTimeMax = 4.0f;
	[SerializeField] private float spawnTimeMin = 1.0f;
	
	private float timeLimit;
	private float timer;
	
	// Use this for initialization
	void Start () {
	
		initialPos = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		UpdateTimer();
		
		Movement();
		
	}
	
	// Function to manage the timer
	void UpdateTimer () {
	
		// Add time to the timer
		timer += Time.deltaTime;
		
		// Check to see if it's time to spawn an enemy
		if (timer >= timeLimit) {
		
			// Set the new timeLimit for the next spawn
			timeLimit = Random.Range (spawnTimeMin, spawnTimeMax);
			
			// Reset the timer to zero
			timer = 0;
			
			// Spawn an enemy
			DoSpawn();
		
		}
	
	}

	void DoSpawn () {
	
		// Choose a random index in the enemy array
		float random = Random.value;
		
		if (random < .45f) {
		
			// Tell the player
			Debug.Log ("The random value is: " + random + ". The powerup spawned is speed.");
		
			// Instantiate the random powerup at the position of the generator
			Instantiate (powerupTypes[0], transform.position, transform.rotation);
		
		} else if (.45f <= random && random < .9f) {
		
			// Tell the player
			Debug.Log ("The random value is: " + random + ". The powerup spawned is mass.");
			
			// Instantiate the random powerup at the position of the generator
			Instantiate (powerupTypes[1], transform.position, transform.rotation);
			
		} else if (.9f <= random && random <= 1f) {
		
			// Tell the player
			Debug.Log ("The random value is: " + random + ". The powerup spawned is instakill.");
			
			// Instantiate the random powerup at the position of the generator
			Instantiate (powerupTypes[2], transform.position, transform.rotation);
			
		}
	
	}

	void Movement () {
	
		moveTimer += moveSpeed * Time.deltaTime;
		
		if (direction.x != 0) {
			
			offset.x = Mathf.PingPong(moveTimer, direction.x);
		
		} else if (direction.y != 0) {
			
			offset.y = Mathf.PingPong(moveTimer, direction.y);
			
		} else if (direction.z != 0) {
			
			offset.z = Mathf.PingPong(moveTimer, direction.z);
			
		}
		
		transform.position = initialPos + offset;
	
	}

}
