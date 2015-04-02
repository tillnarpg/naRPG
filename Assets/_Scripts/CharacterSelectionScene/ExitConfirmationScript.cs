using UnityEngine;
using System.Collections;

public class ExitConfirmationScript : MonoBehaviour {

	public void yesButtonPressed()
	{
		// Debug.Log("Yes Button Pressed, Exiting the Application");
		Application.Quit ();
	}

	public void noButtonPressed()
	{
		// Debug.Log("No Button Pressed, returning to Menu");
		this.gameObject.SetActive (false);
	}
	

}
