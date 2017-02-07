// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/06/2017

// Credit: Learn to Code By Making Games - Ben Tristem

// Purpose: A script to manage the music throughout the levels

// -------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChange;
	
	private AudioSource audioSource;

	void Awake () {
	
		DontDestroyOnLoad (gameObject);
	
	}
	
	void Start () {
	
		audioSource = GetComponent<AudioSource>();
		
		PlayerPrefsManager.SetMasterVolume(.75f);
		
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();	
	
	}
	
	void OnLevelWasLoaded (int _level) {
	
		AudioClip thisLevelMusic = levelMusicChange[_level];
	
		Debug.Log ("Music playing for level: " + thisLevelMusic);
	
		if (thisLevelMusic) {
		
			audioSource.clip = thisLevelMusic;

			audioSource.loop = true;
			
			audioSource.Play();
		
		}
	
	}
	
	public void ChangeVolume (float _volume) {
	
		audioSource.volume = _volume;
	
	}
	
}
