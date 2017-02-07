// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/07/2017

// Credit: Learn to Code By Making Games - Ben Tristem

// Purpose: A script to manage the fades on UI Panels

// -------------------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour {

	public float fadeInTime;
	private Image fadePanel;
	private Color currentColor = Color.black;
	

	// Use this for initialization
	void Start () {
	
		fadePanel = GetComponent<Image>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Time.timeSinceLevelLoad < fadeInTime) {
		
			// Fade In
			
			float alphaChange = Time.deltaTime / fadeInTime;
			
			currentColor.a -= alphaChange;
			
			fadePanel.color = currentColor;
		
		} else {
		
			gameObject.SetActive(false);
		
		}
	
	}
}
