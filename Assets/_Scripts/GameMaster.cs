using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{
    public GameObject gameSettings;
    
    
    private GameSettings gsScript;

	GameObject gs = null;

	void Awake()
	{
		DontDestroyOnLoad(this);
	}


    // Use this for initialization
    void Start()
    {

        //Connect to the GameSettings Object and create it from Prefab if there is no GameSettings-GO.
		gs = GameObject.Find("GameSettings");
        if (!gs)
        {
			Debug.Log("Creating a new GameSettingsObject");
			gs = Instantiate(gameSettings, Vector3.zero, Quaternion.identity) as GameObject;
            gs.name = "GameSettings";
        }
        gsScript = gs.GetComponent<GameSettings>();


		Debug.Log ("Am I here? what's my name then? " + gs.name);
        LoadCharacter();

    }

    public void LoadCharacter()
    {
       gsScript.LoadCharacterData();
    }
}
