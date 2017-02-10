// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/08/2017

// Credit: alucardj - http://answers.unity3d.com/questions/276273/how-to-make-something-like-3-2-1-go.html

// Purpose: A script to identify the death collider

// -------------------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Countdown : MonoBehaviour {

	public Text countdownText;

	public AudioClip beep;
	public AudioClip go;

	private AudioSource audioSource;

//	private bool showCountdown = false;

	// Use this for initialization
	void Start () {

//		countdownText = GetComponent<Text>();
	
	}
	
	// Update is called once per frame
	void Update () {

		
	
	}

	public IEnumerator RunCountdown () {

		audioSource = GetComponent<AudioSource>();

//		showCountdown = true;

		countdownText.text = "";
		yield return new WaitForSeconds (2f);

		audioSource.PlayOneShot(beep);
		countdownText.text = "3";
		yield return new WaitForSeconds (1f);

		audioSource.PlayOneShot(beep);
		countdownText.text = "2";
		yield return new WaitForSeconds (1f);

		audioSource.PlayOneShot(beep);
		countdownText.text = "1";
		yield return new WaitForSeconds (1f);

		audioSource.PlayOneShot(go);
		countdownText.text = "GO";
		yield return new WaitForSeconds (1f);

		countdownText.text = "";

//		showCountdown = false;

	}

}
