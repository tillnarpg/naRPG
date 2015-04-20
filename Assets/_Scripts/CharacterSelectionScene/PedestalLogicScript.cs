using UnityEngine;
using System.Collections;

public class PedestalLogicScript : MonoBehaviour {

	int myNumber;
	string myName;
    bool myActive = false;

	public GameObject characterCreationScreen; // new approach. Not loading a new level. Instead using a new canvas. 

	public GameObject playerPrefab;
	public GameObject characterSpawner;
	GameObject characterOnPedestal;

	// GameMaster Object
	public GameObject gameMaster;

//***************************************************************************//
//***************************************************************************//
    void Awake()
    {
        myName = this.name;
        myNumber = int.Parse(myName[myName.Length - 1].ToString()); // Funny way of getting the number of the pedestal. Inside this we have the proper number now.
    }

	void Start()
	{
		characterOnPedestal = GameObject.Find (myName + "/CharacterSpawner/pc"); // looking if there is a player class already in the scene. 
	}

//***************************************************************************//
//***************************************************************************//

	public void SpawnCharacter( int pedestalPosition )
	{
        if(!myActive) return;

		characterOnPedestal = GameObject.Find (myName + "/pc" + pedestalPosition); // looking if there is a player class already in the scene. 

		if( playerPrefab == null )  // Checking for a playerPrefab 
		{
			Debug.Log ("Hey, dummy, you forgot to link to the player prefab in the inspector!");
			return;
		}

		if (!characterOnPedestal)  // checking if the actualy pedestal has a character standing on it
		{
            characterCreationScreen.SetActive(true);

			// No character on the pedestal it's safe to create a new character!

            // The following 2 lines of code are probably completely useless, because CharacterSpawner on top on Pedestal Object has the GameMasterScript attached.
            //characterOnPedestal = GameObject.Instantiate(gameMaster , characterSpawner.transform.position, Quaternion.identity) as GameObject;
            //characterOnPedestal.transform.parent = transform;
		}
	}

//***************************************************************************//
	public void DeleteCharacter()
	{
        if( !myActive) return;
		// characterOnPedestal = GameObject.Find (myName + "/CharacterSpawner/pc"); // looking if there is a player class already in the scene. 

		Debug.Log ("PedestalLogicScript: I'm in DeleteChar!");

		if (characterOnPedestal) 
		{
			Debug.Log("Destroying Character!");
			Destroy (characterOnPedestal);
		}
	}

//***************************************************************************//
    public void SetPedestalActive( int positionNumber )
    { 
        // Debug.Log("My number " +myNumber + " positionNumber " + positionNumber + " myActive " + myActive );
        if( myNumber == positionNumber ) 
        {
            myActive = true;
        }
        else
        {
            myActive = false;
        }
    }

//***************************************************************************//
    public bool CheckIfActiveHasCharacter()
    { 
        if( myActive && characterOnPedestal ) return true;
        return false;
    }

//***************************************************************************//
    public void SetNewCharacterPedestalPosition( GameObject newCharacter )
    { 
        if( myActive )
        { 
            characterOnPedestal = newCharacter;
            characterOnPedestal.transform.position = characterSpawner.transform.position;
            characterOnPedestal.transform.parent = transform;
        }
    }
//***************************************************************************//
    public void SetDontDestroyActive()
    { 
        if(myActive)
        {
            gameObject.GetComponentInChildren<DontDestroyScript>().enabled = true;
            gameObject.transform.DetachChildren();
            gameObject.transform.rotation = Quaternion.identity;
            Debug.Log("Inside SetDontDestroyActive");
        }
    }

//***************************************************************************//
    public void TurnCharacter( int turnForce ) // Totally wrong approach! Change it in the future!
    { 
        if(!myActive) return;
        if(!characterOnPedestal) return;

        characterOnPedestal.transform.Rotate( Vector3.up , turnForce *20 );
    }
}
