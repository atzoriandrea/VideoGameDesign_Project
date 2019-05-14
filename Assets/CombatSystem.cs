using System.Collections;
using UnityEngine;


public class CombatSystem : MonoBehaviour
{
    public Transform player;
    public float walkingDistance = 25.0f;
    public float smoothTime = 1.0f;
    Vector3 movement;
    private Vector3 smoothVelocity = Vector3.zero;
    ArrayList enemies;
    ArrayList temp1, temp2, temp3;
    public ArrayList scripts, checkAlive;
    PlayerController giocatore;
    ArrayList readytoAttack;
    Animator anim, control;
    Transform tr;
    static bool attacking;
    int nearest;
    float mostnear;
    float distance;
    int i;
    GameObject weapon;
    public Camera maincamera;
    Controller contr, info, selected;
    string prova;
    // Use this for initialization
    void Start()
    {
        readytoAttack = new ArrayList();
        enemies = new ArrayList();
        attacking = false;
        giocatore = GameObject.Find("Character_Hero_Knight_Male").GetComponent<PlayerController>();
        temp1 = new ArrayList(GameObject.FindGameObjectsWithTag("Standard"));
        temp2 = new ArrayList(GameObject.FindGameObjectsWithTag("Agile"));
        temp3 = new ArrayList(GameObject.FindGameObjectsWithTag("Bruto"));
        player = GameObject.Find("Character_Hero_Knight_Male").transform;
        
        foreach (GameObject e in temp3)
            enemies.Add(e);
        foreach (GameObject e in temp2)
            enemies.Add(e);
        foreach (GameObject e in temp1)
            enemies.Add(e);
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(enemies.Count);
        i = 0;
        nearest = 999;
        checkAlive = new ArrayList();
        readytoAttack = null;
        readytoAttack = new ArrayList();
        foreach (GameObject cop in enemies)
        {
            if (cop.GetComponent<EnemyControllerStd>().ready && cop.GetComponent<EnemyInfo>()._health > 0 && cop.GetComponent<EnemyControllerStd>().onScreen)
            {
                readytoAttack.Add(i);
                distance = Vector3.Distance(cop.transform.position, player.position);
                if (nearest == 999)
                {
                    nearest = i;
                    mostnear = distance;
                    selected = cop.GetComponent<EnemyControllerStd>();             
                }
                else
                {
                    if (distance < mostnear)
                    {
                        nearest = i;
                        mostnear = distance;
                        selected = cop.GetComponent<EnemyControllerStd>();
                    }
                }
            }        
            i++;
        }
        //se esistono nemici pronti ad attaccare, seleziona il più vicino e lo fa avvicinare a distanza di attacco
        if (readytoAttack.Count > 0 && !attacking)
        {
            attacking = true;
            tr = ((GameObject)enemies[nearest]).GetComponent<Transform>();
            tr.LookAt(player);
            anim = ((GameObject)enemies[nearest]).GetComponent<Animator>();
            if (Vector3.Distance(tr.position, player.position) >= 2)
            {
                anim.SetBool("walking", true);
            }
            else
            {
                weapon = tr.Find("Root").Find("Hips").Find("Spine_01").Find("Spine_02").Find("Spine_03").Find("Clavicle_R").Find("Shoulder_R").Find("Elbow_R").Find("Hand_R").Find("Thumb_01 1").Find("Arma").gameObject;
                anim.SetTrigger("swordattack");
                tr = null;
            }
        }
        //se qualcuno è in fase di attacco, termina la fase per non entrare in loop infinito
        if (anim != null && (attacking || (selected != null && selected._health <= 0)))
        {
            attacking = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Arma") && anim.GetCurrentAnimatorStateInfo(0).IsName("sword_att"))
        {
            giocatore.TakeDamage(selected.damage);
        }
    }
}