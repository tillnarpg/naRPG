using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour
{
	GameObject rotator;
	private int aktPlayer;
    PlayerStats[] player;

    void Awake()
    {
        DontDestroyOnLoad(this);
        rotator = GameObject.FindGameObjectWithTag("Rotator");

        //RotatorLogicScript RotatorScript = rotator.GetComponent<RotatorLogicScript>();
        //aktPlayer = RotatorScript.GetPedestalPosition();
    }

    void Start()
    { 
        player = new PlayerStats[rotator.GetComponent<RotatorLogicScript>().GetNumberOfPedestals()];
    }

    public void SaveCharacterData( string objectName )
    {
        GameObject pc = GameObject.Find(objectName);
        PlayerStats pcClass = pc.GetComponent<PlayerStats>();

        PlayerPrefs.SetString("PLAYERNAME", pcClass.Name);
        PlayerPrefs.SetInt("GENDER", pcClass.Gender);
        PlayerPrefs.SetInt("CLASS", pcClass.Class);
    }

    public void LoadCharacterData()
    {
        GameObject[] pc = GameObject.FindGameObjectsWithTag("PlayerCharacter");
        if( pc == null ) return;
        for( int i=0 ; i < rotator.GetComponent<RotatorLogicScript>().GetNumberOfPedestals() ; i++ )
        {
            player[i] = pc[i].GetComponent<PlayerStats>();

            player[i].Name = PlayerPrefs.GetString("PLAYERNAME", "No Name");
            player[i].Gender = PlayerPrefs.GetInt("GENDER", 0);
            player[i].Class = PlayerPrefs.GetInt("CLASS", 0);
        }
    }
}
