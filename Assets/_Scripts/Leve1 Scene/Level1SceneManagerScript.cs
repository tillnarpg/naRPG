using UnityEngine;
using System.Collections;

public enum State { running, paused }

public class Level1SceneManagerScript : MonoBehaviour {

    public GameObject gameMenu;
    public GameObject uDeadMenu;
    //public GameObject gameController;
    public GameObject exitConfirmation;
    public GameObject exitToMenuConfirmation;


    public IState gameState;
   
    
    GameObject gameCharacter;

    public MenuActiveScript menuScript;


//************************************************************************//
//************************************************************************//
    void Awake()
    { 
        gameCharacter = GameObject.FindGameObjectWithTag("Player");
        if(!gameCharacter) return;
        gameCharacter.GetComponent<Collider>().enabled = false;

        //gameCharacter.transform.position = gameController.transform.position;
        //gameCharacter.transform.rotation = gameController.transform.rotation;
        //gameCharacter.transform.parent = gameController.transform;

        gameState = new Running();
    }

//************************************************************************//    

	void Start () 
    {
        menuScript = gameObject.GetComponent<MenuActiveScript>();
	}

//************************************************************************//
//************************************************************************//

    void Update() { 
        if (Input.GetKeyUp("escape") ) {
            Debug.Log("Got ESC Key");
            gameState.changeMenuState(this);
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
    /*
    private void changeMenuState()
    {
        switch (gameState) {
            case State.paused:
                gameMenu.SetActive(true);
                Time.timeScale = 0.0f;
                menuScript.SetScriptsOff();
                break;
            case State.running:
                gameMenu.SetActive(false);
                Time.timeScale = 1.0f;
                menuScript.SetScriptsOn();
                break;
            default:
                break;
        }
    }*/

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
        //setgameState(State.paused);
        //changeMenuState();
        gameState.changeMenuState(this);
        PlayerDeathMenu();
    }
}


