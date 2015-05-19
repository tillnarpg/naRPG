using UnityEngine;
using System.Collections;

public class WelcomeScreenTestScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	    GameObject go = GameObject.FindGameObjectWithTag("TestedObject");
        go.GetComponent<SceneManagerScript>().ExitButtonPressed();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
