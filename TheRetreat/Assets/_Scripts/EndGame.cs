using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Application.Quit();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("QUITTING");
		Application.Quit();
	}
}
