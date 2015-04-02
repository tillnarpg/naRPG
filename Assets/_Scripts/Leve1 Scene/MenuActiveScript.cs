using UnityEngine;
using System.Collections;

public class MenuActiveScript : MonoBehaviour {


    // This Scripts disables the MouseLook script on the CharacterController, so it's easy to "fiddle" with the game Menu


    public MouseLook cameraComponent;
    public MouseLook playerComponent;
    
    public void SetScriptsOff()
    { 
        //gameObject.GetComponent<MouseLook>().enabled = false;
        //gameObject.GetComponentInChildren<MouseLook>().enabled = false;
        cameraComponent.enabled = false;
        playerComponent.enabled = false;
    }

    public void SetScriptsOn()
    {
        //gameObject.GetComponent<FPSInputController>().enabled = true;
        //gameObject.GetComponentInChildren<MouseLook>().enabled = true;
        cameraComponent.enabled = true;
        playerComponent.enabled = true;
    }
}
