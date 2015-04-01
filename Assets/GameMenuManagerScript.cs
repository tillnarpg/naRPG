using UnityEngine;
using System.Collections;

public class GameMenuManagerScript : MonoBehaviour {

    bool menuPauseOn = false;

    public GameObject gameMenu;
    public GameObject exitConfirmation;
    public GameObject exitToMenuConfirmation;

//************************************************************************//
//************************************************************************//

    void Update()
    {
        if (Input.GetKeyUp("escape"))
        {
            if (gameMenu.activeInHierarchy == false)
            {
                gameMenuPause();
            }
            else if (gameMenu.activeInHierarchy == true && exitConfirmation.activeInHierarchy == false && exitToMenuConfirmation.activeInHierarchy == false)
            {
                gameMenuPause();
            }
        }
    }

//************************************************************************//
//************************************************************************//
    public void ExitGame()
    {
        // Debug.Log("Exiting Game!");
        exitConfirmation.SetActive(true);
    }

    public void ExitToMenu()
    {
        // Debug.Log("Exiting Game!");

        exitToMenuConfirmation.SetActive(true);
    }
//************************************************************************//
    public void gameMenuPause()
    {
        menuPauseOn = !menuPauseOn;
        gameMenu.SetActive(menuPauseOn);
        Debug.Log("menuPauseOn = " + menuPauseOn);
    }

//************************************************************************//
}
