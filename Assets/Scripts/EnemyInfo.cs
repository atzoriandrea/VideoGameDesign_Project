using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : Controller {

    Animator anim;
    public Player player;
    public PlayerController playerController;
    private CharacterController _enemyCont;
    void Start()
    {
        _enemyCont = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        playerController = GameObject.Find("Character_Hero_Knight_Male").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("swordcollider") && playerController.attacking)
        {
            Hurt(50);
        }
    }
   
    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log(_health);
        if (_health <= 0)
        {
            anim.SetTrigger("death");
            anim.SetBool("isDead", true);
            //transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            _enemyCont.height = 0;
            _enemyCont.radius = 0;
            playerController.GetExperience(3);
        }
    }


}
