using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour {

	public static int EnemyLeben = 50;
	
	void OnGUI()
	{
		string LebenText = "Enemy Lifepoints " + EnemyLeben;
		GUI.Box(new Rect(20,75, 150, 30),LebenText);
	}

	void Update () {
		if(EnemyLeben<=0){
			Destroy(this.gameObject);
		}
		
	}

}


