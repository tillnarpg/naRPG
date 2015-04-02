using UnityEngine;
using System.Collections;

public class WarningConfirmationScript : MonoBehaviour {

    public GameObject warningImage;
    public void okButton()
    { 
        warningImage.SetActive(false);
    }
}
