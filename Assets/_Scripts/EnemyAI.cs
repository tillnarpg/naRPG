using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	bool TriggerEnter = false;


	private Transform myTransform;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") 
		{
				TriggerEnter = true;
		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			TriggerEnter = false;
		}
	}
	void Awake(){
			myTransform = transform;

	}
	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag ("Player");

			target = go.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (TriggerEnter==true) {		
			Debug.DrawLine (target.position, myTransform.position, Color.yellow);

			//Look at target
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);

			// Move towards target
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
	}
}

























