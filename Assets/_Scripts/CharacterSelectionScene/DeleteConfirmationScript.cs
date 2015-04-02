using UnityEngine;
using System.Collections;

public class DeleteConfirmationScript : MonoBehaviour {

    public GameObject rotator;
    PedestalLogicScript[] pedestals;
    void Start()
    { 
        pedestals = rotator.GetComponentsInChildren<PedestalLogicScript>();
        
    }

	public void yesButtonPressed()
	{
		Debug.Log("<Yes> Button Pressed, Deleting the Character");
        for( int i=0 ; i < rotator.GetComponent<RotatorLogicScript>().GetNumberOfPedestals()  ; i++ )
        { 
            pedestals[i].DeleteCharacter();
        }
        this.gameObject.SetActive(false);
	}

	public void noButtonPressed()
	{
		Debug.Log("<No> Button Pressed, returning to Menu");
		this.gameObject.SetActive (false);
	}
	

}
