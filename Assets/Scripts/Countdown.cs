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

//	private bool showCountdown = false;

	// Use this for initialization
	void Start () {

//		countdownText = GetComponent<Text>();

		countdownText.text = "3";
	
	}
	
	// Update is called once per frame
	void Update () {

		
	
	}

	public IEnumerator RunCountdown () {

//		showCountdown = true;
		
		countdownText.text = "3";
		yield return new WaitForSeconds (1f);

		countdownText.text = "2";
		yield return new WaitForSeconds (1f);

		countdownText.text = "1";
		yield return new WaitForSeconds (1f);

		countdownText.text = "GO";
		yield return new WaitForSeconds (1f);

		countdownText.text = "";

//		showCountdown = false;

	}

}
