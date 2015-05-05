using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown(KeyCode.F)){
			Attack();
		}

	}

	private void Attack(){
		//if (target != null) {
			float distance = Vector3.Distance (target.transform.position, transform.position);

			Debug.Log (distance);
			if (distance < 2) {
				EnemyAI.EnemyLeben = EnemyAI.EnemyLeben - 10;
			}
		//}
	}
}