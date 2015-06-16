using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Targetting : MonoBehaviour {


    public List<Transform> targets;
	public Transform selectedTarget;

    private Transform myTransform;

	// Use this for initialization
	void Start () {
        targets = new List<Transform>();
        selectedTarget = null;
        myTransform = transform;

        AddAllEnemies();
	}

    public void AddAllEnemies()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");
		targets.Clear ();

        foreach (GameObject enemy in go)
            AddTarget(enemy.transform);
    }

    public void AddTarget(Transform enemy)
    {
        targets.Add(enemy);
    }

    private void SortTargetsByDistance()
    {
        targets.Sort(delegate(Transform t1, Transform t2)
        {
            return Vector3.Distance(t1.position, myTransform.position).CompareTo(Vector3.Distance(t2.position, myTransform.position));
        });
    }
    private void TargetEnemy()
    {
		if (targets.Count > 0) {

			//if (selectedTarget == null) {
				AddAllEnemies ();
				SortTargetsByDistance ();
				selectedTarget = targets [0];
//			} else {
//				int index = targets.IndexOf (selectedTarget);
//				if (index < targets.Count - 1) {
//					index++;
//				} else {
//					index = 0;
//				}
//				DeselectTarget ();
//				selectedTarget = targets [index];
//			}		
			SelectTarget ();
		} else {
			selectedTarget=null;
		}
    }

    private void SelectTarget()
    {
       // selectedTarget.GetComponent<Renderer>().material.color = Color.red;

        PlayerAttack pa = (PlayerAttack)GetComponent("PlayerAttack");
        pa.target = selectedTarget.gameObject;
    }

    private void DeselectTarget()
    {
      //  selectedTarget.GetComponent<Renderer>().material.color = Color.white;
        selectedTarget = null;
    }
	// Update is called once per frame
	void Update () {
        TargetEnemy();
	}

}
