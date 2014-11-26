using UnityEngine;
using System.Collections;

public class PedestalLogicScript : MonoBehaviour {

	int myNumber;
	string myNameBuffer = null;
	char[] myName;

	public GameObject playerPrefab;
	public GameObject characterSpawner;
	GameObject characterOnPedestal;

	// GameMaster Object
	public GameObject gameMaster;

	void Start()
	{
		myName = this.name;
		myName = myNameBuffer.ToCharArray ();
		int.TryParse( myName [myName.Length - 1], out myNumber);

		Debug.Log (myName + " " + myNumber);

		characterOnPedestal = GameObject.Find ("pc");
	}



	public void SpawnCharacter( int pedestalPosition )
	{
		Debug.Log ("PedestalLogicScript: I'm in SpawnChar!");
		if( playerPrefab == null )
		{
			Debug.Log ("Hey, dummy, you forgot to link to the player prefab in the inspector!");
			return;
		}
		if (!characterOnPedestal) 
		{
			characterOnPedestal = GameObject.Instantiate(gameMaster , characterSpawner.transform.position, Quaternion.identity) as GameObject;
			characterOnPedestal.transform.parent = transform;

			Application.LoadLevel("CharacterGeneration");
//			characterOnPedestal = GameObject.Instantiate( gameMaster, characterSpawner.transform.position , Quaternion.identity ) as GameObject;

		}
		if (characterOnPedestal) 
		{
			Debug.Log("I'm in the SpawnChar if with characterOnPedestal");
			characterOnPedestal.transform.position = characterSpawner.transform.position;
			characterOnPedestal.transform.parent = transform;
		}
	}

	public void DeleteCharacter()
	{
		Debug.Log ("PedestalLogicScript: I'm in DeleteChar!");
		if (characterOnPedestal) 
		{
			Destroy (characterOnPedestal);
		}
	}

}
