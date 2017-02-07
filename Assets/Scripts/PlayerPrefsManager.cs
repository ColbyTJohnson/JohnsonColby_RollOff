// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/07/2017

// Credit: Learn to Code By Making Games - Ben Tristem

// Purpose: A script to manage the player prefs

// -------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	
	const string DIFFICULTY_KEY = "difficulty";
	
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume (float _volume) {
	
		if (_volume >= 0f && _volume <= 1f) {
	
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, _volume);
		
		} else {
		
			Debug.LogError ("Master volume out of range!");
		
		}
	
	}
	
	public static float GetMasterVolume () {
	
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	
	}
	
	public static void UnlockLevel (int _level) {
	
		if (_level <= Application.levelCount - 1) {
		
			PlayerPrefs.SetInt(LEVEL_KEY + _level.ToString(), 1); // Use 1 for true
		
		} else {
		
			Debug.LogError ("Trying to unlock level not in build");
		
		}
	
	}
	
	public static bool IsLevelUnlocked (int _level) {
	
		int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + _level.ToString());
		
		bool isLevelUnlocked = (levelValue == 1);
	
		if (_level <= Application.levelCount -1) {
		
			// return bool
			return isLevelUnlocked;
		
		} else {
		
			Debug.LogError ("Level not in index");
			return false;
		
		}
	
	}
	
	public static void SetDifficulty (float _difficulty) {
		
		if (_difficulty >= 1f && _difficulty <= 3f) {
			
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, _difficulty);
			
		} else {
			
			Debug.LogError ("Difficulty out of range!");
			
		}
		
	}
	
	public static float GetDifficulty () {
		
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
		
	}

}
