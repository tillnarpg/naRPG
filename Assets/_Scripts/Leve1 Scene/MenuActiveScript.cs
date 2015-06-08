using UnityEngine;
using System.Collections;

public class MenuActiveScript : MonoBehaviour {


    // This Scripts disables the MouseLook script on the CharacterController, so it's easy to "fiddle" with the game Menu


    public MouseLook cameraComponent;
    public MouseLook playerComponent;
    
    public void SetScriptsOff()
    { 
        cameraComponent.enabled = false;
        playerComponent.enabled = false;
    }

    public void SetScriptsOn()
    {
        cameraComponent.enabled = true;
        playerComponent.enabled = true;
    }
}
