using UnityEngine;
using System.Collections;

public class ExitToMenuConfirmationScript : MonoBehaviour
{

    public void yesButtonPressed()
    {
        Application.LoadLevel(0);
    }

    public void noButtonPressed()
    {
        this.gameObject.SetActive(false);
    }


}
