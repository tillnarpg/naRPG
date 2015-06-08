using UnityEngine;
using System.Collections;

public class ExitConfirmationScript : MonoBehaviour {

	public void yesButtonPressed()
	{
		Application.Quit ();
	}

	public void noButtonPressed()
	{
		this.gameObject.SetActive (false);
	}
	

}
