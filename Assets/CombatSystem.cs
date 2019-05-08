using System.Collections;
using UnityEngine;


public class CombatSystem : MonoBehaviour {
    public Transform player;
    public float walkingDistance = 25.0f;
    public float smoothTime = 1.0f;
    Vector3 movement;
    private Vector3 smoothVelocity = Vector3.zero;
    ArrayList enemies;
    ArrayList temp1, temp2, temp3;
    public ArrayList scripts;

    ArrayList readytoAttack;
    Animator anim;
    Transform tr;
    static bool attacking;
    int nearest;
    float mostnear;
    float distance;
    Controller contr, info, selected;

    // Use this for initialization
    void Start () {
        readytoAttack = new ArrayList();
        scripts = new ArrayList();
        enemies = new ArrayList();
        attacking = false;
        Object[] agili = new Object[3];
        Object[] bruti = new Object[3];
        Object[] standard = new Object[3];


        temp1 = new ArrayList(GameObject.FindGameObjectsWithTag("Standard"));
        temp2 = new ArrayList(GameObject.FindGameObjectsWithTag("Agile"));
        temp3 = new ArrayList(GameObject.FindGameObjectsWithTag("Bruto"));
        player = GameObject.Find("Character_Hero_Knight_Male").transform;

        foreach (GameObject e in temp2)
        {
            enemies.Add(e);
            agili[0] = e.GetComponent<EnemyControllerAgile>();
            agili[1] = e.GetComponent<EnemyInfoAgile>();
            agili[2] = e.GetComponent<Transform>();
            scripts.Add(agili);
        }
        foreach (GameObject e in temp3)
        {
            enemies.Add(e);
            bruti[0] = e.GetComponent<EnemyControllerBrute>();
            bruti[1] = e.GetComponent<EnemyInfoBrute>();
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
	void Update () {
        int i = 0;
        tr = null;
        readytoAttack = null;
        readytoAttack = new ArrayList();
        selected = null;
        foreach (Object[] cop in scripts) {
            if (((Controller)cop[0]).ready && ((Controller)cop[1])._health > 0)
            {
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
            if (Vector3.Distance(tr.position, player.position) >= 3)
            {
                anim.SetBool("walking", true);
                anim.SetBool("running", false);
                anim.SetBool("walkback", false);

            }
            else if (Vector3.Distance(tr.position, player.position) < 3 && Vector3.Distance(tr.position, player.position) > 1.5)
            {
                anim.SetTrigger("swordattack");
            }
            else
            {
                anim.SetBool("walkback", true);
                anim.SetBool("walking", false);
                anim.SetBool("running", false);

            }
        }
       
        //se qualcuno è in fase di attacco, termina la fase per non entrare in loop infinito
        if ((attacking && anim != null)/*|| (selected != null && selected._health <= 0)*/)
        {
            attacking = false;
            anim = null;
        }

    }
}
