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

    public void Hurt(int damage)
    {
        _health -= damage;
        if (_health <= 0)
            anim.SetTrigger("death");
        Debug.Log("Health: " + _health);
    }
}
