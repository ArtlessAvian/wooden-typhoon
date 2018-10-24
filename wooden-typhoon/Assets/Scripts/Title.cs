using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

	// UnityEngine.SceneManagement.Scene hubScene; 
	UnityEngine.SceneManagement.Scene stageScene;


	// Use this for initialization
	void Start () {
		SceneManager.LoadSceneAsync("Stage", LoadSceneMode.Single);
	}
	
	// Update is called once per frame
	void Update () {
		SceneManager.SetActiveScene(SceneManager.GetSceneByName("Stage"));
	}
}
