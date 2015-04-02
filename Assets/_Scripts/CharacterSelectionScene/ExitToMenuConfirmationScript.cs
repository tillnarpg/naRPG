using UnityEngine;
using System.Collections;

public class ExitToMenuConfirmationScript : MonoBehaviour
{

    public void yesButtonPressed()
    {
        // Debug.Log("Yes Button Pressed, Exiting to the Menu");
        Application.LoadLevel(0);
    }

    public void noButtonPressed()
    {
        // Debug.Log("No Button Pressed, returning to Scene");
        this.gameObject.SetActive(false);
    }


}
