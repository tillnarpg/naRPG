using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpideyBehaviourTest : MonoBehaviour
{
    public bool isTestPassed = false ;

    void OnCollisionEnter ( Collision goc )
    {
        if ( isTestPassed ) return;

        if ( goc.gameObject.name == "Player" )
        { 
            isTestPassed = true;
        }
    }
}


