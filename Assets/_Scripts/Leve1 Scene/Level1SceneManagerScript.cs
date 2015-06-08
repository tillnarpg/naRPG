using UnityEngine;
using System.Collections;

public enum State { running, paused }

public class Level1SceneManagerScript : MonoBehaviour {

    public GameObject gameMenu;
    public GameObject uDeadMenu;
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
        exitConfirmation.SetActive(true);
    }

    public void ExitToMenu()
    {
        exitToMenuConfirmation.SetActive(true);
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
        gameState.changeMenuState(this);
        PlayerDeathMenu();
    }
}


