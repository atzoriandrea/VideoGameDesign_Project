using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    // Use this for initialization
    private int _health;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        _health = 100;
    }

    
}
