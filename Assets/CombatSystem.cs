using System.Collections;
using UnityEngine;


public class CombatSystem : MonoBehaviour {
    public Transform player;
    public float walkingDistance = 25.0f;
    public float smoothTime = 1.0f;
    Vector3 movement;
    ArrayList enemies;
    ArrayList temp1, temp2, temp3;
    public static ArrayList scripts;
    ArrayList readytoAttack;
    Animator anim;
    bool attacking;
    float distance;
    Controller contr, info;
    // Use this for initialization
    void Start () {
        readytoAttack = new ArrayList();
        scripts = new ArrayList();
        enemies = new ArrayList();
        attacking = false;
        Controller[] c = new Controller[2];
        temp1 = new ArrayList(GameObject.FindGameObjectsWithTag("Standard"));
        temp2 = new ArrayList(GameObject.FindGameObjectsWithTag("Agile"));
        temp3 = new ArrayList(GameObject.FindGameObjectsWithTag("Bruto"));
        foreach (GameObject e in temp1)
        {
            enemies.Add(e);
            c[0] = e.GetComponent<EnemyControllerStd>();
            c[1] = e.GetComponent<EnemyInfo>();
            scripts.Add(c);
        }
        foreach (GameObject e in temp2) {
            enemies.Add(e);
            c[0] = e.GetComponent<EnemyControllerAgile>();
            c[1] = e.GetComponent<EnemyInfoAgile>();
            scripts.Add(c);
        }
        foreach (GameObject e in temp3) {
            enemies.Add(e);
            c[0] = e.GetComponent<EnemyControllerBrute>();
            c[1] = e.GetComponent<EnemyInfoBrute>();
            scripts.Add(c);
        }
            
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //Debug.Log("Nemici: " + enemies.Count + "; Scripts: " + scripts.Count + "; Pronti ad attaccare: " + readytoAttack.Count);
        Debug.Log(readytoAttack.ToString());

        if (!attacking) {
            int i = 0;
            foreach (Controller[] cop in scripts) {
                if (cop[0].ready && cop[1]._health > 0)
                {
                    readytoAttack.Add(i);
                    i++;
                }
            }
            i = 0;
            if (readytoAttack.Count > 0)
                attacking = true;
            int x = (int)Random.Range(0, readytoAttack.Count - 1);
            anim = ((GameObject)enemies[x]).GetComponent<Animator>() ;
            anim.SetTrigger("swordattack");
            if(!anim.GetCurrentAnimatorStateInfo(0).IsName("sword_att") && attacking)
                attacking = false;
            readytoAttack = null;
            readytoAttack = new ArrayList(); 

        }
        
	}
}
