using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerAgile : Controller {

    public Transform player;
    public float walkingDistance = 25.0f;
    public float smoothTime = 1.0f;
    private Vector3 smoothVelocity = Vector3.zero;
    Vector3 movement;
    

    Animator anim;
    float distance;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Character_Hero_Knight_Male").transform;
    }
    void Update()
    {
        
        if (EnemyInfo.health > 0) {
            //il nemico è sempre rivolto verso il giocatore
            transform.LookAt(player);
            //distanza tra nemico e giocatore
            distance = Vector3.Distance(transform.position, player.position);
            //camminata nemico
            if (distance < walkingDistance && distance > 2)
            {
                //Il nemico viene sempre verso il giocatore
                transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
                anim.SetBool("walking", true);
                anim.SetBool("running", false);
                ready = false;

            }
            else if (distance < walkingDistance * 8 && distance > walkingDistance) {
                transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
                anim.SetBool("running", true);
                anim.SetBool("walking", true);
                ready = false;

            }
            else if (distance < 2) {
                /*int temp;
                temp = Random.Range(0, 50);
                if (temp == 0)
                    anim.SetTrigger("swordattack");*/
                ready = true;

                anim.SetBool("running", false);
                anim.SetBool("walking", false);
            }
        }
    }
}
