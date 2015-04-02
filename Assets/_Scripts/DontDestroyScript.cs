using UnityEngine;
using System.Collections;

public class DontDestroyScript : MonoBehaviour {

	void Awake () 
    {
	    DontDestroyOnLoad(gameObject);
	}
}
