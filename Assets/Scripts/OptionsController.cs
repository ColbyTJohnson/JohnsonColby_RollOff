// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/07/2017

// Credit: Learn to Code By Making Games - Ben Tristem

// Purpose: A script to manage the options in the menu

// -------------------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public LevelManager levelManager;
	
	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
	
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		musicManager.ChangeVolume (volumeSlider.value);
	
	}
	
	public void SaveAndExit () {
	
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		
		levelManager.LoadLevel("01 Start Menu");
	
	}
	
	public void SetDefaults () {
	
		volumeSlider.value = .75f;
	
	}
	
}
