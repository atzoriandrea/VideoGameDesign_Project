using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoss : MonoBehaviour {
    public GameObject guard1, guard2, guard3, guard4, boss;
	// Use this for initialization
	void Start () {
        guard1.GetComponent<EnemyControllerStd>().stop = true;
        guard2.GetComponent<EnemyControllerStd>().stop = true;
        guard3.GetComponent<EnemyControllerStd>().stop = true;
        guard4.GetComponent<EnemyControllerStd>().stop = true; 
        boss.GetComponent<EnemyControllerStd>().stop = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Character_Hero_Knight_Male")) {
            guard1.GetComponent<EnemyControllerStd>().stop = false; 
            guard2.GetComponent<EnemyControllerStd>().stop = false;
            guard3.GetComponent<EnemyControllerStd>().stop = false;
            guard4.GetComponent<EnemyControllerStd>().stop = false; 
            boss.GetComponent<EnemyControllerStd>().stop = false; 
        }
    }
}
