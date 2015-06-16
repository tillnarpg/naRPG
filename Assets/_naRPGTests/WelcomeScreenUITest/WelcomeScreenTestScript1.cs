using UnityEngine;
using System.Collections;

public class WelcomeScreenTestScript1 : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	    GameObject go = GameObject.FindGameObjectWithTag("TestedObject");
        go.GetComponent<ExitConfirmationScript>().noButtonPressed();
	}
}
