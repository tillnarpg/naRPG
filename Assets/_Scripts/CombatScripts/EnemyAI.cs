using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    public int maxDistance;  // Wie weit er höchstens entfernt sein darf zum verfolgen
	public int minDistance;  // Wie weit er midestens entfernt sein muss um zu verfolgen

	public bool PlayerInRange;
    private Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }
	// Use this for initialization
	void Start () 
    {
		PlayerInRange = false;
        GameObject go = GameObject.FindGameObjectWithTag("PlayerTag");

        target = go.transform;

        maxDistance = 2;
		minDistance = 10;
	}
	
	// Update is called once per frame
	void Update () 
    {
        Debug.DrawLine(target.position, myTransform.position, Color.yellow);
		float distance = Vector3.Distance (target.position, myTransform.position);
		if (Vector3.Distance (target.position, myTransform.position) > maxDistance && Vector3.Distance (target.position, myTransform.position) < minDistance) 
        {
			PlayerInRange = true;
			//Look at target
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);

			//Move towards target
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		} 
        else if (distance > minDistance) 
        {
			PlayerInRange = false;

		}

      
	}
}
