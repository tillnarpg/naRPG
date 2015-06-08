using UnityEngine;
using System.Collections;

public class RotatorState4Script : StateMachineBehaviour {

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // set position 4
        RotatorLogicScript rotator = animator.gameObject.GetComponent<RotatorLogicScript>();
        rotator.SelectedCharacter4();
    }
}
