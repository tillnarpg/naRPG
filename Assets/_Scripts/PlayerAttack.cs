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
		EnemyLife.EnemyLeben = EnemyLife.EnemyLeben - 10;
	}
}