using UnityEngine;
using System.Collections;

public class CharacterCreationTest : MonoBehaviour {


	void Start () 
    {
        
        



        RotatorLogicScript rotScript = gameObject.GetComponent<RotatorLogicScript>();

        rotScript.CreateCharacter();
	}
}
