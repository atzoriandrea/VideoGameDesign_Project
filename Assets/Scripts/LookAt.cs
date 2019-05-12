using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    // Use this for initialization
    GameObject player;
	void Start () {
        player = GameObject.Find("Character_Hero_Knight_Male");
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Transform>().LookAt(player.transform.position);
	}
}
