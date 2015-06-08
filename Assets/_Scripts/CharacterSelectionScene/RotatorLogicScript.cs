using UnityEngine;
using System.Collections;

public class RotatorLogicScript : MonoBehaviour {

	Animator anim;

	float direction;
	int position = 1; // Selected pedestal 1. 

    public GameObject characterCreationUI;
	public GameObject loadingImage;
    public GameObject warningImage;
	public GameObject exitConfirmation;
    public GameObject exitToMenuConfirmation;
	public GameObject deleteConfirmation;
	public Light[] spotlights;	

    
    PedestalLogicScript[] pedestalScript;


    const int numberOfPedestals = 4;


//***************************************************************************//
//***************************************************************************//

	void Awake()
	{
        Time.timeScale = 1.0f; // Resets the timeScale in the condition that we would get back to this menu after exiting to Main Menu.
		LightsControl ( position );
	}

//***************************************************************************//

	void Start () 
	{
		anim = gameObject.GetComponent<Animator>();
		anim.SetInteger ("Position", position);   // used for rotation with left and right ( 'a' ,'d' ) keys
        anim.SetFloat("Direction", 0.0f);


        pedestalScript = this.gameObject.GetComponentsInChildren<PedestalLogicScript>();
        changeActive();
	}


//***************************************************************************//
//***************************************************************************//

	// Update is called once per frame
	void Update () 
	{

        // Blocks changes to pedestals when another panel is active!
        bool ready = (!characterCreationUI.activeInHierarchy && !loadingImage.activeInHierarchy && !warningImage.activeInHierarchy && !exitConfirmation.activeInHierarchy && !deleteConfirmation.activeInHierarchy);
        if (ready) 
        {
            HandleSelectionInput();
        }
	}

    private void HandleSelectionInput()
    {
        // KEY SELECTION!
        direction = Input.GetAxis("Horizontal");
        anim.SetFloat("Direction", direction);

        // MOUSE SELECTION 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "_Pedestal1" || hit.collider.name == "pc1")
                    SelectedCharacter1();


                if (hit.collider.name == "_Pedestal2" || hit.collider.name == "pc2")
                    SelectedCharacter2();


                if (hit.collider.name == "_Pedestal3" || hit.collider.name == "pc3")
                    SelectedCharacter3();


                if (hit.collider.name == "_Pedestal4" || hit.collider.name == "pc4")
                    SelectedCharacter4();

            }
        }
    }
//***************************************************************************//
//***************************************************************************//

	void SelectedCharacter0()   // needed only for Rotator Animation purposes. 
	{
		position = 0;   
		LightsControl ( position );
		anim.SetInteger("Position", position);
		Debug.Log("Selected Nothing ");

	}

	public void SelectedCharacter1()   // Event called either by clicking on the pedestal or by animation controller
	{
		position = 1;
		LightsControl ( position );
		anim.SetInteger("Position", position);
		Debug.Log("Selected Pedestal 1 ");
        changeActive();
	}

    public void SelectedCharacter2() // Event called either by clicking on the pedestal or by animation controller
	{
		position = 2;
		LightsControl ( position );
		anim.SetInteger("Position", position);
		Debug.Log("Selected Pedestal 2 ");
        changeActive();
	}

    public void SelectedCharacter3()  // Event called either by clicking on the pedestal or by animation controller
	{
		position = 3;
		LightsControl ( position );
		anim.SetInteger("Position", position);
		Debug.Log("Selected Pedestal 3 ");
        changeActive();
	}

    public void SelectedCharacter4() // Event called either by clicking on the pedestal or by animation controller
	{
		position = 4;
		LightsControl ( position );
		anim.SetInteger("Position", position);
		Debug.Log("Selected Pedestal 4 ");
        changeActive();
	}


//***************************************************************************//

	void LightsControl( int spotlightNumber )   // Controls the lights on the pedestals. Lights only the Active Pedestal
	{

		if (spotlightNumber == 0) 
		{
			for (int i = 0 ; i < spotlights.Length ; i++)
				spotlights[i].enabled = false;
		}

		if (spotlightNumber > 0) 
		{
			for ( int i = 1 ; i <= spotlights.Length ; i++)
			{
				if(   i == spotlightNumber ) 
				{
					spotlights[i-1].enabled = true;
				}
				else 
				{
					spotlights[i-1].enabled = false;
				}

			}
		}
	}

//***************************************************************************//
//***************************************************************************//

	public void CreateCharacter()  // Initiated by the button Create Character click. 
	{
        
		string pedestalName = "_Pedestal"; // Getting the Pedestal name for 
		pedestalName += position;  

		Debug.Log ("CreateCharacter: PedestalName is " + pedestalName);

		GameObject pedestal = GameObject.Find (pedestalName);

		PedestalLogicScript spawnerScript = pedestal.GetComponent<PedestalLogicScript>();
        Debug.Log("this spawnerscript" + spawnerScript.name);
		spawnerScript.SpawnCharacter( position );
	}

//***************************************************************************//

	public void DeleteCharacter()
	{
		
        string findThis = gameObject.name + "_Pedestal" + position + "/pc" + position;

        if( !GameObject.Find(findThis) ) return;

        deleteConfirmation.SetActive(true);
	}

//***************************************************************************//

	public void StartGame()
	{
        bool charFound = false;
        for (int i = 0; i < numberOfPedestals; i++)
        {
            if (pedestalScript[i].CheckIfActiveHasCharacter()) 
            {
                charFound = true;
                loadingImage.SetActive(true);
                pedestalScript[i].SetDontDestroyActive(); // Activates the Dont Destroy Script on the perticular Player Character.
                Application.LoadLevel("Level1"); // Loads the first level. 
            }
        }
        if (!charFound) warningImage.SetActive(true);
	}

	public void ExitGame()
	{
		exitConfirmation.SetActive(true);
	}

    public void ExitToMenu()
    {
        exitToMenuConfirmation.SetActive(true);
    }



//***************************************************************************//
    private void changeActive() // Changing the myActive bool in Pedestal Object. 
    {
        for (int i = 0; i < numberOfPedestals ; i++)
        {
            pedestalScript[i].SetPedestalActive(position);
        }
    }

//***************************************************************************//
//********************      GET FUNCTIONS      ******************************//
        

    public int GetNumberOfPedestals() // getting the number of Pedestals.
    { 
        return numberOfPedestals;
    }

//***************************************************************************//
    public int GetPedestalPosition()
    {
        return position;
    }

//***************************************************************************//
//***************************************************************************//
    public void rotateCharacterLeft() // Button <LEFT> 
    {
        for (int i = 0; i < numberOfPedestals; i++)
        {
            pedestalScript[i].TurnCharacter(-1);
        }
    }

//***************************************************************************//
    public void rotateCharacterRight() // Button <RIGHT>
    {
        for (int i = 0; i < numberOfPedestals; i++)
        {
            pedestalScript[i].TurnCharacter(1);
        }
    }

//***************************************************************************//


}