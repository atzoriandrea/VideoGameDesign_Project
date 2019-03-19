using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour {

    // Use this for initialization
    public static int _health;
    Animator anim;
    //Collider collider;
   private CharacterController _enemyCont;
    void Start()
    {
        _enemyCont = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        _health = 100;
    }

    void FixedUpdate()
    {
        Debug.Log("Enemy Life: " + _health);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("hit");
        //Hurt(50);
        if (other.name.Equals("swordcollider"))
        {
            Debug.Log("hit");
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
        Debug.Log("Health: " + _health);
    }

    public static int getHealth() {
        return _health;
    }
}
