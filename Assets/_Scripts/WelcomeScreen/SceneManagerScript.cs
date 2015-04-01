using UnityEngine;
using System.Collections;

public class SceneManagerScript : MonoBehaviour {

    public GameObject exitConfirmation;
    public GameObject loadingImage;

    public void ExitButtonPressed()
    { 
        exitConfirmation.SetActive(true);
    }

    public void StartButtonPressed()
    { 
        loadingImage.SetActive(true);
        Application.LoadLevel(1);
    }

}
