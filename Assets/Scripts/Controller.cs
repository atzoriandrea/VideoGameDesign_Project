using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public bool ready;
    public int _health;
    public bool move;
    public static int  health;
    public float damage;
    public bool onScreen;

    // Use this for initialization
    void Start () {
		
	}
	// Update is called once per frame
	void Update () {
        health = _health;
	}
}
