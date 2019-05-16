﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : Controller {

    Animator anim;
    public Player player;
    public PlayerController playerController;
    private CharacterController _enemyCont;
    public GameObject lastEnemy2;
    void Start()
    {
        _enemyCont = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        playerController = GameObject.Find("Character_Hero_Knight_Male").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (playerController.attacking)
        {
            if (other.name.Equals("swordcollider"))
                Hurt(other.gameObject.GetComponent<Sword>().damage);
            if (other.name.Equals("AlabardaCollider"))
                Hurt(40);
        }
        if(other.gameObject.tag.Equals("Arrow"))
            Hurt(20);
    }
   
    public void Hurt(int damage)
    {
        if (this.tag.Equals("Boss"))
        {
            this.GetComponent<LastEnemy>().health -= (damage/2);
            if (this.GetComponent<LastEnemy>().health <= 0)
            {
                anim.SetTrigger("death");
                anim.SetBool("isDead", true);
                lastEnemy2.SetActive(true);
                _enemyCont.height = 0;
                _enemyCont.radius = 0;
            }
        }
        else if (this.tag.Equals("Boss2"))
        {
            this.GetComponent<LastEnemyV2>().health -= (damage/2);
            if (this.GetComponent<LastEnemyV2>().health <= 0)
            {
                anim.SetTrigger("death");
                anim.SetBool("isDead", true);
                _enemyCont.height = 0;
                _enemyCont.radius = 0;
            }
        }
        else
        {
            _health -= damage;
            if (_health <= 0)
            {
                anim.SetTrigger("death");
                anim.SetBool("isDead", true);
                _enemyCont.height = 0;
                _enemyCont.radius = 0;
                playerController.GetExperience(3);
            }
        }
    }


}
