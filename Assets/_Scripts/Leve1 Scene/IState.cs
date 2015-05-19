using UnityEngine;
using System.Collections;

public abstract class IState
{
    public abstract void changeMenuState(Level1SceneManagerScript scene);

    /*internal void changeMenuState(Level1SceneManagerScript level1SceneManagerScript)
    {
        throw new System.NotImplementedException();
    }*/
}

class Running : IState
{
    public override void changeMenuState(Level1SceneManagerScript scene)
    {
        scene.gameMenu.SetActive(true);
        Time.timeScale = 0.0f;
        //scene.menuScript.SetScriptsOff();
        scene.gameState = new Paused();
    }
}

class Paused : IState
{
    public override void changeMenuState(Level1SceneManagerScript scene)
    {
        scene.gameMenu.SetActive(false);
        Time.timeScale = 1.0f;
        //scene.menuScript.SetScriptsOn();
        scene.gameState = new Running();
    }

}