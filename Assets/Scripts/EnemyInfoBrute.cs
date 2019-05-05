﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfoBrute : Controller {

    Animator anim;
   private CharacterController _enemyCont;
    void Start()
    {
        _enemyCont = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        _health = 150;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("swordcollider") && PlayerController.attacking)
        {
          
            Hurt(50);
        }
    }
   
    public void Hurt(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            anim.SetTrigger("death");
            anim.SetBool("isDead", true);
            _enemyCont.height = 0;
            _enemyCont.radius = 0;
        }
    }

    public static int getHealth() {
        return health;
    }
}
