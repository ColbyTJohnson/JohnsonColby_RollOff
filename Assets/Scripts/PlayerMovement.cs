// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/07/2017

// Credit: AddTorque - Unity Official Tutorials

// Credit: Unity Standard Assets - Ball.cs

// Purpose: A script to manage Player Movement

// -------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] private float movePower = 5f;
	[SerializeField] private float torquePower = 5f;
	[SerializeField] private bool useTorque = true;
	[SerializeField] private float maxAngularVelocity = 25f;
	[SerializeField] private float jumpPower = 2f;

	public AudioClip jumpSound;

	private const float k_GroundRayLength = 2f;
	private Rigidbody rigidbody;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {

		rigidbody = GetComponent<Rigidbody>();
		rigidbody.maxAngularVelocity = maxAngularVelocity;

		audioSource = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {

		
	
	}

	public void Move (Vector3 moveDirection, bool jump) {

		rigidbody = GetComponent<Rigidbody>();
		rigidbody.maxAngularVelocity = maxAngularVelocity;

		if (useTorque) {

			rigidbody.AddTorque (new Vector3 (moveDirection.z, 0, -moveDirection.x) * torquePower);

//		} else {

			rigidbody.AddForce (moveDirection * movePower);

		}

		if (Physics.Raycast (transform.position, -Vector3.up, k_GroundRayLength) && jump) {

			rigidbody.AddForce (Vector3.up * jumpPower, ForceMode.VelocityChange);
			audioSource.PlayOneShot (jumpSound);

		}

	}

}
