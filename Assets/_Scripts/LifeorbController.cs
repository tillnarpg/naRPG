﻿using UnityEngine;
using System.Collections;

public class LifeorbController : MonoBehaviour {

    //muss später in den Spieler übertragen werden:
    public static int PlayerLeben = 100;

    void OnGUI()
    {
        string LebenText = "Your Lifepoints" + PlayerLeben;
        GUI.Box(new Rect(20, 20, 150, 50),LebenText);
    }

}
