using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CharacterGenerator : MonoBehaviour
{
    private PlayerStats _player;

    public Text nameInputfield;
    public Slider genderSlider;
    public Slider classSlider;
    private const int STARTING_EXP = 150;
    public GameObject gameSettings;
    public GameObject playerPrefab;

    private GameSettings gsScript;

    // Use this for initialization
    void Start()
    {
        //Connect to the GameSettings Object and create it from Prefab if there is no GameSettings-GO.
        GameObject gs = GameObject.Find("GameSettings");
        if (gs == null)
        {
            gs = Instantiate(gameSettings, Vector3.zero, Quaternion.identity) as GameObject;
            gs.name = "GameSettings";
        }
        gsScript = gs.GetComponent<GameSettings>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateCharacter()
    {
        GameObject pc = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        pc.name = "pc";

        _player = pc.GetComponent<PlayerStats>();

        // _player = gameObject.AddComponent("PlayerCharacter") as PlayerCharacter;
        //_player = new PlayerCharacter ();
        //Instantiate(_player);
        _player.Awake();
        _player.Name = nameInputfield.text;
        _player.Gender = (int)genderSlider.value;
        _player.Class = (int)classSlider.value;
        //Debug.Log("PlayerName: " + _player.Name);
        //Debug.Log("PlayerGender: " + _player.Gender);
        //Debug.Log("PlayerClass: " + Enum.GetName(typeof(PlayerClass),_player.Class));

        GameObject gs = GameObject.Find("GameSettings");
        GameSettings gsScript = gs.GetComponent<GameSettings>();

        gsScript.SaveCharacterData();

		Application.LoadLevel("CharacterCreationScene");

    }

    private void CreateWarrior()
    {

    }

    private void CreateMage()
    {

    }
}
