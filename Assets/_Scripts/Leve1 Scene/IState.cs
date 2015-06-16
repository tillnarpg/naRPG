using UnityEngine;
using System.Collections;

public abstract class IState
{
    public abstract void changeMenuState( Level1SceneManagerScript scene );
}

class Running : IState
{
    public override void changeMenuState( Level1SceneManagerScript scene )
    {
        GameObject player = GameObject.FindGameObjectWithTag("PlayerTag");
        MouseLook[] CameraScript = player.GetComponentsInChildren<MouseLook>();

        CameraScript[0].enabled = false;
        CameraScript[1].enabled = false;

        scene.gameMenu.SetActive(true);
        Time.timeScale = 0.0f;

        scene.gameState = new Paused();
    }
}

class Paused : IState
{
    public override void changeMenuState( Level1SceneManagerScript scene )
    {
        GameObject player = GameObject.FindGameObjectWithTag( "PlayerTag" );
        MouseLook[] MouseScript = player.GetComponentsInChildren<MouseLook>( );

        MouseScript[0].enabled = true;
        MouseScript[1].enabled = true;


        scene.gameMenu.SetActive(false);
        Time.timeScale = 1.0f;
        scene.gameState = new Running();
    }

}