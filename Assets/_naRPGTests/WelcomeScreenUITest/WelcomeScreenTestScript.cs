using UnityEngine;
using System.Collections;

public class WelcomeScreenTestScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	    GameObject go = GameObject.FindGameObjectWithTag("TestedObject");
        if (go == null)
        {
            Debug.Log( "No object found" );
        }
        go.GetComponent<SceneManagerScript>().ExitButtonPressed();
	}
}
