using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CharacterGenerator : MonoBehaviour
{
    private PlayerStats _player;
	

    public int maxNameLength = 20; // Maximal length of a character length.
    
    public GameObject inputNameField; // game object that controls the name input

    public Text nameInputField;
    public Slider genderSlider;
    public Slider classSlider;
    private const int STARTING_EXP = 150;
    public GameObject gameSettings;
    public GameObject malePlayerPrefab;
    public GameObject femalePlayerPrefab;

    private GameSettings gsScript;
    private GameObject gs = null;

    public GameObject rotator;
    private RotatorLogicScript rotatorScript;

    PedestalLogicScript[] pedestalScript;
    // Use this for initialization
    void Start()
    {
        //Connect to the GameSettings Object and create it from Prefab if there is no GameSettings-GO.
        gs = GameObject.FindGameObjectWithTag("GameSettings");  // PROBABLY USELESS! As the object will always be there.
        if (!gs)
        {
            gs = Instantiate(gameSettings, Vector3.zero, Quaternion.identity) as GameObject;
			Debug.Log("CharacterGenerator Script: Creating new GameSettings Object = " +gs.ToString());
            gs.name = "GameSettings";
        }
        gsScript = gs.GetComponent<GameSettings>();
        rotatorScript = rotator.GetComponent<RotatorLogicScript>();
        pedestalScript = rotator.GetComponentsInChildren<PedestalLogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // Nothing to do for every Frame...
    }

    public void CreateCharacter()  // Called by CREATE button in the Character Creation Panel.
    {
        GameObject pc;

        if( nameInputField.text == "" ) return; // Doesn't allow to create a character without a name.

        if( (int)genderSlider.value == 0 )
        {
            pc = Instantiate(malePlayerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        }
        else
        {
            pc = Instantiate(femalePlayerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        }
        pc.name = "pc" + rotatorScript.GetPedestalPosition();
        pc.GetComponent<DontDestroyScript>().enabled = false; // sets the don't destroy script on false.
        _player = pc.GetComponent<PlayerStats>();

        _player.Awake();
        _player.Name = nameInputField.text;
        _player.Gender = (int)genderSlider.value;
        _player.Class = (int)classSlider.value;

        Debug.Log("PlayerName: " + _player.Name);
        Debug.Log("PlayerGender: " + _player.Gender);
        Debug.Log("PlayerClass: " + Enum.GetName(typeof(PlayerClass),_player.Class));

        gsScript = gs.GetComponent<GameSettings>();

        gsScript.SaveCharacterData( pc.name );

        for(int i=0; i < rotatorScript.GetNumberOfPedestals() ; i++)
        { 
            pedestalScript[i].SetNewCharacterPedestalPosition( pc ); // Sets the position on newly created character on top of the active pedestal.
        }

        inputNameField.GetComponent<InputField>().text = "";
        GoBack ();
    }

	public void GoBack()
	{
		this.gameObject.SetActive (false);
	}

    private void CreateWarrior()
    {
        // For further implementations 
    }

    private void CreateMage()
    {
        // For further implementations 
    }
}
