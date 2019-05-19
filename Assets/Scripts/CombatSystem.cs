﻿using System.Collections;
using UnityEngine;


public class CombatSystem : MonoBehaviour
{
    public Transform player;
    public float walkingDistance = 25.0f;
    public float smoothTime = 1.0f;
    Vector3 movement;
    ArrayList enemies;
    ArrayList temp1, temp2, temp3, temp4, temp5;
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
    public AudioClip hit;
    public AudioClip hit2;
    public AudioClip heavyhit;
    public AudioClip heavyhit2;
    public AudioClip heavyhit3;
    public AudioClip heavyhit4;
    public AudioClip hit3;
    public GameObject comandi;
    private AudioSource source;
    // Use this for initialization
    void Start()
    {
        if (readytoAttack.Count > 0)
            comandi.SetActive(true);
        else
            comandi.SetActive(false);

        readytoAttack = new ArrayList();
        enemies = new ArrayList();
        attacking = false;
        giocatore = GameObject.Find("Character_Hero_Knight_Male").GetComponent<PlayerController>();
        temp1 = new ArrayList(GameObject.FindGameObjectsWithTag("Standard"));
        temp2 = new ArrayList(GameObject.FindGameObjectsWithTag("Agile"));
        temp3 = new ArrayList(GameObject.FindGameObjectsWithTag("Bruto"));
        temp4 = new ArrayList(GameObject.FindGameObjectsWithTag("Boss"));
        temp5 = new ArrayList(GameObject.FindGameObjectsWithTag("Boss2"));
        player = GameObject.Find("Character_Hero_Knight_Male").transform;
        source = GetComponent<AudioSource>();

        foreach (GameObject e in temp3)
            enemies.Add(e);
        foreach (GameObject e in temp2)
            enemies.Add(e);
        foreach (GameObject e in temp1)
            enemies.Add(e);
        foreach (GameObject e in temp4)
            enemies.Add(e);
        foreach (GameObject e in temp5)
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
                //weapon = tr.Find("Root").Find("Hips").Find("Spine_01").Find("Spine_02").Find("Spine_03").Find("Clavicle_R").Find("Shoulder_R").Find("Elbow_R").Find("Hand_R").Find("Thumb_01 1").Find("Arma").gameObject;
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
            if (selected.gameObject.tag.Equals("Bruto"))
                HeavySound();
            else
                NormalSound();
            
        }
        if (other.name.Equals("BossSword") && anim.GetCurrentAnimatorStateInfo(0).IsName("sword_att"))
        {
            NormalSound();
            giocatore.TakeDamage(30);
        }
        if (other.name.Equals("BossSecondWeapon") && anim.GetCurrentAnimatorStateInfo(0).IsName("sword_att"))
        {
            HeavySound();
            giocatore.TakeDamage(40);
        }
    }
    private void HeavySound() {
        switch ((new System.Random()).Next(0,4))
        {
            case 0:
                source.PlayOneShot(heavyhit);
                break;
            case 1:
                source.PlayOneShot(heavyhit2);
                break;
            case 2:
                source.PlayOneShot(heavyhit3);
                break;
            case 3:
                source.PlayOneShot(heavyhit4);
                break;
        }
    }
    private void NormalSound()
    {
        switch ((new System.Random()).Next(0, 3))
        {
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
    }
}