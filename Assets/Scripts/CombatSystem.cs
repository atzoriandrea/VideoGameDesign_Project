using System.Collections;
using UnityEngine;


public class CombatSystem : MonoBehaviour
{
    public Transform player;
    public float walkingDistance = 25.0f;
    public float smoothTime = 1.0f;
    Vector3 movement;
    ArrayList enemies;
    ArrayList temp1, temp2, temp3;
    GameObject boss, bossTwo;
    public ArrayList scripts, checkAlive;
    PlayerController giocatore;
    ArrayList readytoAttack;
    public GameObject pauseMenu;
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
    private ArrayList morti; 
    // Use this for initialization
    void Start()
    {
        //Vengono raccolti tutti i nemici della scena, viene inibito il movimento dei boss e dei relativi scagnozzi
        readytoAttack = new ArrayList();
        enemies = new ArrayList();
        attacking = false;
        giocatore = GameObject.Find("Character_Hero_Knight_Male").GetComponent<PlayerController>();
        temp1 = new ArrayList(GameObject.FindGameObjectsWithTag("Standard"));
        temp2 = new ArrayList(GameObject.FindGameObjectsWithTag("Agile"));
        temp3 = new ArrayList(GameObject.FindGameObjectsWithTag("Bruto"));
        boss = GameObject.Find("LastEnemyLv1");
        bossTwo = GameObject.Find("LastEnemyLv2") ;
        player = GameObject.Find("Character_Hero_Knight_Male").transform;
        source = GetComponent<AudioSource>();

        foreach (GameObject e in temp3)
            enemies.Add(e);
        foreach (GameObject e in temp2)
            enemies.Add(e);
        foreach (GameObject e in temp1)
            enemies.Add(e);
        enemies.Add(boss);
        enemies.Add(bossTwo);
        bossTwo.GetComponent<EnemyControllerStd>().stop = true;

    }
    // Update is called once per frame
    void Update()
    {

        i = 0;//reset dell'indice
        nearest = 999; //valore generico per indicare che è il primo nemico di cui si misura la distanza dal player
        
        readytoAttack = null;
        readytoAttack = new ArrayList(); //lista degli indici dei giocatori pronti ad attaccare
        if (morti != null && morti.Count > 0) //i nemici morti vengono tolti dalla lista
        {
            foreach (GameObject dead in morti)
                enemies.Remove(dead);
        }
        morti = new ArrayList();
        foreach (GameObject cop in enemies)//si ciclano tutti i nemici
        {//si controlla che il nemico in oggetto sia vivo, pronto ad attaccare, e visibile a schermo
            if (cop.GetComponent<EnemyControllerStd>().isActiveAndEnabled && cop.GetComponent<EnemyControllerStd>().ready && cop.GetComponent<EnemyInfo>()._health > 0 && cop.GetComponent<EnemyControllerStd>().onScreen && cop.activeSelf)
            {
                readytoAttack.Add(i);
                distance = Vector3.Distance(cop.transform.position, player.position);
                if (nearest == 999) //raccolta nemico più vicino
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
            if (cop.GetComponent<EnemyInfo>()._health <= 0) //se il nemico muore, viene aggiunto alla lista dei nemici da rimuovere da enemies
            {
                morti.Add(cop);
            }
            i++;
        }
        
        if (readytoAttack.Count > 0 && !pauseMenu.activeSelf)//i comandi sono visibili se il menu di pausa non è attivo e qualche nemico è a distanza di attacco
            comandi.SetActive(true);
        else
            comandi.SetActive(false);
        //se esistono nemici pronti ad attaccare, seleziona il più vicino e lo fa avvicinare a distanza di attacco
        if (readytoAttack.Count > 0 && !attacking) // si setta il fatto che un nemico stia attaccando (il più vicino), in modo da impedire agli altri di fare lo stesso
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

    //Rileva le collisioni del player con le armi dei nemici
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Arma") && anim.GetCurrentAnimatorStateInfo(0).IsName("sword_att"))
        {
            giocatore.TakeDamage(selected.damage);
            if (selected.gameObject.tag.Equals("Bruto"))
                HeavySound();
            else
                NormalSound();
            
        }//Arma del boss di livello 1
        if (other.name.Equals("BossSword") && anim.GetCurrentAnimatorStateInfo(0).IsName("sword_att"))
        {
            NormalSound();
            giocatore.TakeDamage(30);
        }//Arma del boss di livello 2
        if (other.name.Equals("BossSecondWeapon") && anim.GetCurrentAnimatorStateInfo(0).IsName("sword_att"))
        {
            HeavySound();
            giocatore.TakeDamage(40);
        }
    }//Suono collisione arma pesante
    private void HeavySound() {
        switch ((new System.Random()).Next(0,4))
        {
            case 0:
                source.PlayOneShot(heavyhit, 0.4f);
                break;
            case 1:
                source.PlayOneShot(heavyhit2, 0.4f);
                break;
            case 2:
                source.PlayOneShot(heavyhit3, 0.4f);
                break;
            case 3:
                source.PlayOneShot(heavyhit4, 0.4f);
                break;
        }
    }//Suono collisione arma normale
    private void NormalSound()
    {
        switch ((new System.Random()).Next(0, 3))
        {
            case 0:
                source.PlayOneShot(hit, 0.1f);
                break;
            case 1:
                source.PlayOneShot(hit2, 0.1f);
                break;
            case 2:
                source.PlayOneShot(hit3, 0.1f);
                break;
        }
    }
}