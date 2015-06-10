using UnityEngine;
using System.Collections;

public class ItemCollect : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        switch(collider.gameObject.name)
        {
            case "Player":

                LifeorbController.PlayerLeben += 50;
                Destroy(this.gameObject);

                break;
            default:
                //DoNothing
                break;
        }
    }

}
