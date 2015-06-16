using UnityEngine;
using System.Collections;

public class MessageAreaBehaviour : MonoBehaviour 
{
    public GameObject chestMessageUI;
    public Animator   chestAnimator;

    void OnTriggerStay( Collider col )
    { 
        if ( col.gameObject.name == "Player" )
        { 
            chestMessageUI.SetActive(true);
        }

        if ( Input.GetKeyDown(KeyCode.F) == true )
        { 
            // Play the opening animation.
            chestAnimator.SetBool( "Open" , true );
        }

    }

    void OnTriggerExit( Collider col )
    {
        if (col.gameObject.name == "Player")
        {
            chestMessageUI.SetActive( false );
        }
    }




}
