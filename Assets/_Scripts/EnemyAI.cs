using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	bool TriggerEnter = false;

	public static int EnemyLeben = 50;

	private Transform myTransform;

	void OnTriggerEnter(Collider other){
		if (other.tag == "PlayerTag") 
		{
				TriggerEnter = true;
		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "PlayerTag") {
			TriggerEnter = false;
		}
	}
	void Awake(){
			myTransform = transform;

	}
	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag ("PlayerTag");

			target = go.transform;
	}
	void OnGUI()
	{
		if (TriggerEnter) {
			string LebenText = "Enemy Lifepoints " + EnemyLeben;
			GUI.Box (new Rect (20, 75, 150, 30), LebenText);

			string AttackText = "Press F to attack";
			GUI.Box(new Rect(200, 20, 130, 30),AttackText);
		}

	}

	// Update is called once per frame
	void Update () {
		if (EnemyLeben <= 0) {
			Destroy (this.gameObject);
		}
		if (TriggerEnter==true) {

			Debug.DrawLine (target.position, myTransform.position, Color.yellow);

			//Look at target
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);

			// Move towards target
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
	}


}