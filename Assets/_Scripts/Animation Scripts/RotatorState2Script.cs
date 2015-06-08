using UnityEngine;
using System.Collections;

public class RotatorState2Script : StateMachineBehaviour {

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // set position 2
        RotatorLogicScript rotator = animator.gameObject.GetComponent<RotatorLogicScript>();
        rotator.SelectedCharacter2();
    }
}
