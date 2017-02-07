// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Roll Off!

// Last Updated: 02/06/2017

// Credit: Learn to Code By Making Games - Ben Tristem

// Purpose: A script to manage the levels

// -------------------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	[Range(0.0f, 10.0f)]
	[SerializeField]
	public float autoLoadNextLevelAfter;
	
	void Start () {
	
		if (autoLoadNextLevelAfter == 0) {
		
			Debug.Log ("No auto load");
		
		} else {
	
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
			
		}
	
	}

	public void LoadLevel (string name) {
	
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene (name);
	
	}

	public void QuitRequest () {
	
		Debug.Log ("Quit requested");
		Application.Quit ();
	
	}
	
	public void LoadNextLevel () {
	
		Debug.Log ("Loading next level");
		
		SceneManager.LoadScene(Application.loadedLevel + 1);	
	
	}

}
