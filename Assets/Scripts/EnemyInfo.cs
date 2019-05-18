using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyInfo : Controller {

    Animator anim;
    public Player player;
    public PlayerController playerController;
    private CharacterController _enemyCont;
    public GameObject lastEnemy2;
    public AudioClip hit;
    public AudioClip hit2;
    public AudioClip hit3;
    private AudioSource source;
    System.Random r;
    void Start()
    {
        _enemyCont = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        r = new System.Random();
        playerController = GameObject.Find("Character_Hero_Knight_Male").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (playerController.attacking)
        {
            if (other.name.Equals("swordcollider"))
            {
                int random = r.Next(0,3);
                switch (random) {
                    case 0:
                        source.PlayOneShot(hit);
                        break;
                    case 1:
                        source.PlayOneShot(hit2);
                        break;
                    case 2:
                        source.PlayOneShot(hit3);
                        break;
                }
                Hurt(other.gameObject.GetComponent<Sword>().damage);

            }
            if (other.name.Equals("AlabardaCollider"))
            {
                Hurt(40);
            }
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
