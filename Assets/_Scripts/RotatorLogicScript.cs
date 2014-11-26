using UnityEngine;
using System.Collections;

public class RotatorLogicScript : MonoBehaviour {


	Animator anim;

	//	int LeftHash = Animator.StringToHash("Base Layer.Left");
//	int RightHash = Animator.StringToHash("Base Layer.Right");
//
	float direction;
	int position = 1; // Selected pedestal 1. 
//	public Transform rotatorTransform;

	public Light[] spotlights;	
	public GameMaster[] gameMasters;	


//***************************************************************************//
//***************************************************************************//

	void Awake()
	{
		LightsControl ( position );
		GameMasterControl ( position );
	}

//***************************************************************************//

	void Start () 
	{
		anim = gameObject.GetComponent<Animator>();

		anim.SetInteger ("Position", position);

//		if (rotatorTransform == null)
//		{
//			Debug.Log("You forgot to set the rotatorObject in place");
//		}


	}


//***************************************************************************//
//***************************************************************************//

	// Update is called once per frame
	void Update () 
	{
		direction = Input.GetAxis("Horizontal");

		// if( anim.GetCurrentAnimationClipState("Base Layer") )
			anim.SetFloat ("Direction", direction);


		// MOUSE SELECTION && TO BE IMPLEMENTED!
		if (Input.GetMouseButtonDown(0)) 
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit))
			{
				if( hit.collider.name == "_Pedestal1" )
					//anim.SetInteger("Position", 1);
					SelectedCharacter1();
					

				if( hit.collider.name == "_Pedestal2")
					//anim.SetInteger("Position", 2);
					SelectedCharacter2();
					

				if( hit.collider.name == "_Pedestal3")
					//anim.SetInteger("Position", 3);
					SelectedCharacter3();
					

				if( hit.collider.name == "_Pedestal4")
					//anim.SetInteger("Position", 4);
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
		GameMasterControl (position);
		anim.SetInteger("Position", position);
		Debug.Log("Selected Nothing ");
	}

	void SelectedCharacter1()
	{
		position = 1;
		LightsControl ( position );
		GameMasterControl (position);
		anim.SetInteger("Position", position);
		Debug.Log("Selected Pedestal 1 ");

	}

	void SelectedCharacter2()
	{
		position = 2;
		LightsControl ( position );
		GameMasterControl (position);
		anim.SetInteger("Position", position);
		Debug.Log("Selected Pedestal 2 ");
	}

	void SelectedCharacter3()
	{
		position = 3;
		LightsControl ( position );
		GameMasterControl (position);
		anim.SetInteger("Position", position);
		Debug.Log("Selected Pedestal 3 ");
	}

	void SelectedCharacter4()
	{
		position = 4;
		LightsControl ( position );
		GameMasterControl (position);
		anim.SetInteger("Position", position);
		Debug.Log("Selected Pedestal 4 ");
	}


//***************************************************************************//

	void LightsControl( int spotlightNumber )
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
					Debug.Log("Light " + i + " was enabled");
				}
				else 
				{
					spotlights[i-1].enabled = false;
					Debug.Log("Light " + i + " was disabled!");
				}

			}
		}
	}

//***************************************************************************//

	void GameMasterControl( int gameMasterNumber )
	{
		
		if (gameMasterNumber == 0) 
		{
			for (int i = 0 ; i < gameMasters.Length ; i++)
				gameMasters[i].enabled = false;
		}
		
		if (gameMasterNumber > 0) 
		{
			for ( int i = 1 ; i <= gameMasters.Length ; i++)
			{
				if(   i == gameMasterNumber ) 
				{
					gameMasters[i-1].enabled = true;
					Debug.Log("Light " + i + " was enabled");
				}
				else 
				{
					gameMasters[i-1].enabled = false;
					Debug.Log("Light " + i + " was disabled!");
				}
				
			}
		}
	}

//***************************************************************************//

	public void CreateCharacter()
	{
		string pedestalName = "_Pedestal";
		pedestalName += position;

		Debug.Log ("CreateCharacter: PedestalName is " + pedestalName);

		GameObject pedestal = GameObject.Find (pedestalName);

		PedestalLogicScript spawnerScript = pedestal.GetComponent<PedestalLogicScript>();
		spawnerScript.SpawnCharacter( position );
	}

//***************************************************************************//

	public void DeleteCharacter()
	{
		string pedestalName = "_Pedestal";
		pedestalName += position;
		
		Debug.Log ("DeleteCharacter: PedestalName is " + pedestalName);
		
		GameObject pedestal = GameObject.Find (pedestalName);
		
		PedestalLogicScript spawnerScript = pedestal.GetComponent<PedestalLogicScript>();
		spawnerScript.DeleteCharacter();
	}

//***************************************************************************//

	public int GetPedestalPosition()
	{
		return position;
	}

	public void StartGame()
	{
		Application.LoadLevel("Level1");
	}

	public void ExitGame()
	{
		Debug.Log("Exiting Game!");
		Application.Quit ();
	}
//***************************************************************************//
}