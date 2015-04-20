using UnityEngine;
using System.Collections;

public class Level1SceneManagerScript : MonoBehaviour {

    public GameObject gameMenu;
    public GameObject uDeadMenu;
    public GameObject gameController;
    public GameObject exitConfirmation;
    public GameObject exitToMenuConfirmation;
    
    
    
    GameObject gameCharacter;

    MenuActiveScript menuScript;


//************************************************************************//
//************************************************************************//
    void Awake()
    { 
        gameCharacter = GameObject.FindGameObjectWithTag("Player");
        if(!gameCharacter) return;
        gameCharacter.GetComponent<Collider>().enabled = false;

        gameCharacter.transform.position = gameController.transform.position;
        gameCharacter.transform.rotation = gameController.transform.rotation;
        gameCharacter.transform.parent = gameController.transform;
    }

//************************************************************************//    

	void Start () 
    {
        menuScript = gameObject.GetComponent<MenuActiveScript>();
	}

//************************************************************************//
//************************************************************************//

    void Update()
    { 
        if (Input.GetKeyUp("escape") )
        {
            if( gameMenu.activeInHierarchy == false )
            {
                gameMenuPauseOn();
            }
            else if (gameMenu.activeInHierarchy == true && exitConfirmation.activeInHierarchy == false && exitToMenuConfirmation.activeInHierarchy == false)
            {
                gameMenuPauseOff();
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
    private void gameMenuPauseOn()
    {
        //Debug.Log("Escape sets true");
        gameMenu.SetActive(true);
        Time.timeScale = 0.0f;
        menuScript.SetScriptsOff();
    }

    public void gameMenuPauseOff()
    {
        //Debug.Log("Escape sets false");
        gameMenu.SetActive(false);
        Time.timeScale = 1.0f;
        menuScript.SetScriptsOn();
    }
//************************************************************************//
    
    private void PlayerDeathMenu()
    {
         uDeadMenu.SetActive(true);
         Time.timeScale = 0.0f;
         menuScript.SetScriptsOff();
    }
    
    public void PlayerDie()
    {
        // do something!
        gameMenuPauseOff();
        PlayerDeathMenu();
    }
}
