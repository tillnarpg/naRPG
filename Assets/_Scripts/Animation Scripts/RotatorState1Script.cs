using UnityEngine;
using System.Collections;

public class RotatorState1Script : StateMachineBehaviour {

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        // set position 1
        RotatorLogicScript rotator = animator.gameObject.GetComponent<RotatorLogicScript>();
        rotator.SelectedCharacter1();
	}
}
