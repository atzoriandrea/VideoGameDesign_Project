using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerStd : Controller{

    public Transform player;
    public float walkingDistance = 25.0f;
    public float smoothTime = 1.0f;
    private Vector3 smoothVelocity = Vector3.zero;
    Vector3 movement;
    public Camera maincamera;
    //public static bool ready;
    Animator anim;
    float distance;
    void Start()
    {
        move = true;
        anim = GetComponent<Animator>();
        player = GameObject.Find("Character_Hero_Knight_Male").transform;
    }
    void Update()
    {
        //Vector3 screenPoint = maincamera.WorldToViewportPoint(transform.position);
        //bool onScreen = /*((Transform)cop[2]).gameObject.GetComponent<Renderer>().isVisible;*/ screenPoint.x > 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1 && screenPoint.z > 0;
        Vector3 directionToTarget = player.position - transform.position;
        float angle = Vector3.Angle(player.forward, directionToTarget);
        onScreen = Mathf.Abs(angle) > 80;
        Debug.Log(gameObject.name + " " + onScreen);
        
        if (!move)
        {
            anim.SetBool("walking", false);
            anim.SetBool("running", false);
        }
        if (EnemyInfo.health <= 0) {
            anim.SetBool("walking", false);
            anim.SetBool("running", false);
            move = false;
            ready = false;
        }
        if (EnemyInfo.health > 0 && move) {
            if (!onScreen && Vector3.Distance(transform.position, player.position) <= 2)
            {
                anim.SetBool("walkback", true);
                anim.SetBool("walking", false);
                anim.SetBool("running", false);
            }
            else if (onScreen || Vector3.Distance(transform.position, player.position) > 2)
            {
                anim.SetBool("walkback", false);
            }
            //il nemico è sempre rivolto verso il giocatore
            transform.LookAt(player);
            //distanza tra nemico e giocatore
            distance = Vector3.Distance(transform.position, player.position);
            //camminata nemico
            if (distance < walkingDistance && distance > 5)
            {
                //Il nemico viene sempre verso il giocatore
                transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
                anim.SetBool("walking", true);
                anim.SetBool("running", false);
                ready = false;
            }
            else if (distance < walkingDistance * 8 && distance > walkingDistance)
            {
                transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
                anim.SetBool("running", true);
                anim.SetBool("walking", false);
                ready = false;
            }
            else if (distance < 5)
            {
                ready = true;
                anim.SetBool("running", false);
                anim.SetBool("walking", false);
            }
            else {
                ready = false;
            }
        }
    }
}
