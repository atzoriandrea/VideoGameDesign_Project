using System.Collections;
using UnityEngine;


public class CombatSystem : MonoBehaviour
{
    public Transform player;
    public float walkingDistance = 25.0f;
    public float smoothTime = 1.0f;
    Vector3 movement;
    private Vector3 smoothVelocity = Vector3.zero;
    public static ArrayList enemies;
    ArrayList temp1, temp2, temp3;
    public ArrayList scripts;
    PlayerController giocatore;
    ArrayList readytoAttack;
    Animator anim;
    Transform tr;
    public static bool attacking;
    public static int nearest;
    float mostnear;
    float distance;
    public static GameObject weapon;
    Controller contr, info, selected;
    GameObject tmp;

    // Use this for initialization
    void Start()
    {
        readytoAttack = new ArrayList();
        scripts = new ArrayList();
        enemies = new ArrayList();
        attacking = false;
        giocatore = GameObject.Find("Character_Hero_Knight_Male").GetComponent<PlayerController>();
        Object[] agili = new Object[3];
        Object[] bruti = new Object[3];
        Object[] standard = new Object[3];
        giocatore = GameObject.Find("Character_Hero_Knight_Male").GetComponent<PlayerController>();
        temp1 = new ArrayList(GameObject.FindGameObjectsWithTag("Standard"));
        temp2 = new ArrayList(GameObject.FindGameObjectsWithTag("Agile"));
        temp3 = new ArrayList(GameObject.FindGameObjectsWithTag("Bruto"));
        player = GameObject.Find("Character_Hero_Knight_Male").transform;

        foreach (GameObject e in temp2)
        {
            enemies.Add(e);
            agili[0] = e.GetComponent<EnemyControllerStd>();
            agili[1] = e.GetComponent<EnemyInfo>();
            agili[2] = e.GetComponent<Transform>();
            scripts.Add(agili);
        }
        foreach (GameObject e in temp3)
        {
            enemies.Add(e);
            bruti[0] = e.GetComponent<EnemyControllerStd>();
            bruti[1] = e.GetComponent<EnemyInfo>();
            bruti[2] = e.GetComponent<Transform>();
            scripts.Add(bruti);
        }

        foreach (GameObject e in temp1)
        {
            enemies.Add(e);
            standard[0] = e.GetComponent<EnemyControllerStd>();
            standard[1] = e.GetComponent<EnemyInfo>();
            standard[2] = e.GetComponent<Transform>();
            scripts.Add(standard);
        }


    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        readytoAttack = new ArrayList();
        foreach (Object[] cop in scripts)
        {
            if (((Controller)cop[0]).ready && ((Controller)cop[1])._health > 0)
            {
                foreach (Object[] cop2 in scripts)
                {
                    if (Vector3.Distance(((Transform)cop[2]).position, ((Transform)cop2[2]).position) < 3)
                    {
                        if (Vector3.Distance(((Transform)cop[2]).position, player.position) <= Vector3.Distance(((Transform)cop2[2]).position, player.position))
                        {
                            ((Controller)cop2[0]).move = false;
                            ((Controller)cop[0]).move = true;
                        }
                        else
                        {
                            ((Controller)cop[0]).move = false;
                            ((Controller)cop2[0]).move = true;

                        }

                    }
                    else
                    {
                        ((Controller)cop[0]).move = true;
                        ((Controller)cop2[0]).move = true;
                    }

                }
                readytoAttack.Add(i);
                distance = Vector3.Distance(((Transform)cop[2]).position, player.position);
                if (i == 0)
                {
                    nearest = i;
                    mostnear = distance;
                    selected = (Controller)cop[1];
                }
                else
                {
                    if (distance < mostnear)
                    {
                        nearest = i;
                        mostnear = distance;
                        selected = (Controller)cop[1];
                    }

                }
                i++;
            }
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
                anim.SetBool("running", false);
            }
            else
            {
                weapon = tr.Find("Root").Find("Hips").Find("Spine_01").Find("Spine_02").Find("Spine_03").Find("Clavicle_R").Find("Shoulder_R").Find("Elbow_R").Find("Hand_R").Find("Thumb_01 1").Find("Arma").gameObject;
                Debug.Log(weapon != null);
                anim.SetTrigger("swordattack");
                tr = null;

            }
        }
        //se qualcuno è in fase di attacco, termina la fase per non entrare in loop infinito
        if (anim != null && (attacking || selected._health <= 0))
        {
            attacking = false;
            anim = null;
        }


    }
    ArrayList SortEnemiesByDistance(ArrayList a)
    {
        ArrayList sorted = new ArrayList();
        foreach (Object[] cop in a)
        {
        }
        return sorted;
    }
}
