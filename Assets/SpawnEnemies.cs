﻿using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

    public GameObject[] spawnerList;
    public GameObject enemyPrefab;

    public bool maxEnemies = false;


    int enemyCount = 0;
    int playerCount = 0;

    
    // Update is called once per frame
	void Update () 
    {
        int i = Random.Range(0, spawnerList.Length);
        Vector3 pos = spawnerList[i].transform.position;

        if (enemyCount >= 100) 
        {
            maxEnemies = true;
        }
        else
        {
            GameObject enemy = (GameObject)Instantiate(enemyPrefab, pos, Quaternion.identity);
            enemy.GetComponent<EnemyAttack>().enabled = false;
            enemyCount++;
        }
    }
}
