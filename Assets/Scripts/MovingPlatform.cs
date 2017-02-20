// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/19/2017

// Purpose: A script to move platforms

// -------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	[SerializeField] private Vector3 direction;

	private Vector3 initialPos;
	private Vector3 offset;
	private float moveTimer;
	[Range(0.1f,100f)] [SerializeField] private float moveSpeed = 1f;

	// Use this for initialization
	void Start () {

		initialPos = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {

		Movement();
	
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
