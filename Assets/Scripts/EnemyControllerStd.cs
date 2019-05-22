using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerStd : Controller{

    public Transform player;
    public float walkingDistance = 25.0f;
    public float smoothTime = 1.0f;
    private Vector3 smoothVelocity = Vector3.zero;
    Vector3 movement;
    public bool stop;
    public Camera maincamera;
    //public static bool ready;
    Animator anim;
    float distance;
    NavMeshAgent navmesh;
    void Start()
    {
        move = true;
        stop = false;
        anim = GetComponent<Animator>();
        player = GameObject.Find("Character_Hero_Knight_Male").transform;
        navmesh = GetComponent<NavMeshAgent>();
        
    }
    void Update()
    {
        //Sincronizza i valori della vita dei boss con i relativi script
        if (gameObject.tag.Equals("Boss"))
        {
            _health = (int)GetComponent<LastEnemy>().health;
            GetComponent<EnemyInfo>()._health = (int)GetComponent<LastEnemy>().health;
            
        }
        if (gameObject.tag.Equals("Boss2"))
        {
            _health = (int)GetComponent<LastEnemyV2>().health;
            GetComponent<EnemyInfo>()._health = (int)GetComponent<LastEnemyV2>().health;
            
        }
        

        //indica se il nemico è visibile dalla camera
        Vector3 directionToTarget = player.position - transform.position;
        float angle = Vector3.Angle(player.forward, directionToTarget);
        onScreen = Mathf.Abs(angle) < 240 && Mathf.Abs(angle) > 120;
        
        //Se il nemico muore, i movimenti devono essere inibiti
        if (EnemyInfo.health <= 0  || anim.GetCurrentAnimatorStateInfo(0).IsName("death")) {
            anim.SetBool("walking", false);
            anim.SetBool("running", false);
            move = false;
            ready = false;
        }

        //Nemico in vita:
        if (EnemyInfo.health > 0 && !stop)
        {
            //Nemico molto vicino, ma alle spalle del giocatore: si allontana camminando all'indietro
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
            //il nemico è sempre rivolto verso il giocatore distanza tra nemico e giocatore
            distance = Vector3.Distance(transform.position, player.position);
            //camminata nemico
            if (distance < walkingDistance && distance > 5)
            {
                //Il nemico viene sempre verso il giocatore
                transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
                anim.SetBool("walking", true);
                anim.SetBool("running", false);
                navmesh.destination = player.position;
                navmesh.speed = 1;
                ready = false;
            }
            else if (distance < walkingDistance * 5 && distance > walkingDistance)
            {
                navmesh.speed = 1;
                transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
                anim.SetBool("running", true);
                anim.SetBool("walking", false);
                navmesh.destination = player.position;
                navmesh.speed = 1;
                ready = false;
            }
            else if (distance < 5)
            {
                navmesh.speed = 0; //se il nemico è molto vicino e sta di fronte al player, viene inibita la navmesh, in modo che mantenga delle distanze realistiche
                transform.LookAt(player);

                ready = true;//si setta il nemico come pronto ad attaccare
                anim.SetBool("running", false);
                anim.SetBool("walking", false);
            }
            else
            {
                ready = false;//non pronto ad attaccare
            }
        }
        else {
            navmesh.speed = 0;
        }
    }
}
