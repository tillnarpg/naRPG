using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{
    public GameObject playerCharacter;
    public GameObject gameSettings;
    
    
    private GameSettings gsScript;
    private GameObject _pc;
    private PlayerStats _pcScript;

    // Use this for initialization
    void Start()
    {
        _pc = Instantiate(playerCharacter, gameObject.transform.position, Quaternion.identity) as GameObject;
		_pc.transform.parent = transform;
        _pc.name = "pc";
        _pcScript = _pc.GetComponent<PlayerStats>();


        //Connect to the GameSettings Object and create it from Prefab if there is no GameSettings-GO.
        GameObject gs = GameObject.Find("GameSettings");
        if (gs == null)
        {
			Debug.Log("Creating a new GameSettingsObject");
			gs = Instantiate(gameSettings, Vector3.zero, Quaternion.identity) as GameObject;
            gs.name = "GameSettings";
        }
        gsScript = gs.GetComponent<GameSettings>();

        LoadCharacter();

    }

    public void LoadCharacter()
    {
       gsScript.LoadCharacterData();
    }
}
