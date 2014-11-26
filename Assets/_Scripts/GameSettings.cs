using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour
{
	private int aktPlayer;
    PlayerStats[] player = new PlayerStats[4];

    void Awake()
    {
        DontDestroyOnLoad(this);
		aktPlayer = 0;
    }

    public void SaveCharacterData()
    {
        GameObject pc = GameObject.Find("pc");
        PlayerStats pcClass = pc.GetComponent<PlayerStats>();

        PlayerPrefs.SetString("PLAYERNAME", pcClass.Name);
        PlayerPrefs.SetInt("GENDER", pcClass.Gender);
        PlayerPrefs.SetInt("CLASS", pcClass.Class);
    }

    public void LoadCharacterData()
    {
        GameObject pc = GameObject.Find("pc");
        PlayerStats pcClass = pc.GetComponent<PlayerStats>();

        pcClass.Name = PlayerPrefs.GetString("PLAYERNAME", "No Name");
        pcClass.Gender = PlayerPrefs.GetInt("GENDER", 0);
        pcClass.Class = PlayerPrefs.GetInt("CLASS", 0);

    }

}
