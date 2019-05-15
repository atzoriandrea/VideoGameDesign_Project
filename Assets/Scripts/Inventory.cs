using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Animations;

public class Inventory : MonoBehaviour {
    private int selected;
    GameObject newBullet;
    Image sword, secondary, third, potion, bendages;
    public GameObject weapon1, weapon2, weapon3, item1, item2;
    Color sw, snd, trd, pot, ben;
    public Animator anim;
    public GameObject freccia;
    public Camera cam;
   
    // Use this for initialization
    void Start () {
        selected = 1;
        sword = GameObject.Find("Sword").GetComponent<Image>();
        sw = sword.color;
        secondary = GameObject.Find("SecondWeapon").GetComponent<Image>();
        snd = secondary.color;
        third = GameObject.Find("ThirdWeapon").GetComponent<Image>();
        trd = third.color;
        potion = GameObject.Find("Potions").GetComponent<Image>();
        pot = potion.color;
        bendages = GameObject.Find("LifePoints").GetComponent<Image>();
        ben = bendages.color;

    }

    // Update is called once per frame
    void Update() {
                     if (newBullet != null && weapon2.active)
        {
            
        }
        if (Input.GetKeyDown("1")  && !CheckPlaying()) {
            anim.SetTrigger("change");
            selected = 1;
            Sword();
        }
        if (Input.GetKeyDown("2") && !CheckPlaying()) {
            anim.SetTrigger("change");
            selected = 2;
            SecondWeapon();
        }
        if (Input.GetKeyDown("3") && !CheckPlaying())
        {
            anim.SetTrigger("change");
            selected = 3;
            ThirdWeapon();
        }
        if (Input.GetKeyDown("4") && !CheckPlaying())
        {
            anim.SetTrigger("change");
            selected = 4;
            Potion();
        }
        if (Input.GetKeyDown("5") && !CheckPlaying())
        {
            anim.SetTrigger("change");
            selected = 5;
            Bendages();
        }
        if (Input.GetButton("Fire1") && (selected == 1 || selected == 3))
        {
            anim.SetTrigger("swordattack");

        }
        if (!Input.GetMouseButton(1) && selected == 2)
        {
            anim.SetBool("shoot", true);
            if (newBullet == null)
            {
                newBullet = (GameObject)Instantiate(freccia) as GameObject;
                newBullet.transform.position = GameObject.Find("ArrowSpawn").transform.position;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 400.0f))
                {
                    GameObject newBall = Instantiate(freccia, cam.transform.position, cam.transform.rotation) as GameObject;
                    //newBall.GetComponent<Rigidbody>().velocity = (hit.point - transform.position).normalized * speed;
                }
            }
           
            if (newBullet != null && Input.GetMouseButtonDown(0))
                newBullet.GetComponent<Rigidbody>().AddForce(GameObject.Find("Character_Hero_Knight_Male").transform.forward);
        }
        if(Input.GetMouseButtonUp(1))
            anim.SetBool("shoot", false);
        if ((selected == 4 || selected == 5 )&& Input.GetButton("Fire1")) {      
           anim.SetTrigger("heal");
        }
    }

    public void Sword()
    {
        sword.color = new Color(sw.r + 0.2f, sw.g + 0.2f, sw.b + 0.2f);
        secondary.color = snd;
        third.color = trd;
        potion.color = pot;
        bendages.color = ben;
        weapon1.SetActive(true);
        weapon2.SetActive(false);
        weapon3.SetActive(false);
        item1.SetActive(false);
        item2.SetActive(false);
    }
    public void SecondWeapon()
    {
        sword.color = sw;
        secondary.color = new Color(snd.r + 0.2f, snd.g + 0.2f, snd.b + 0.2f);
        third.color = trd;
        potion.color = pot;
        bendages.color = ben;
        weapon1.SetActive(false);
        weapon2.SetActive(true);
        weapon3.SetActive(false);
        item1.SetActive(false);
        item2.SetActive(false);
    }

    public void ThirdWeapon()
    {
        sword.color = sw;
        secondary.color = snd;
        third.color = new Color(snd.r + 0.2f, snd.g + 0.2f, snd.b + 0.2f);
        potion.color = pot;
        bendages.color = ben;
        weapon1.SetActive(false);
        weapon2.SetActive(false);
        weapon3.SetActive(true);
        item1.SetActive(false);
        item2.SetActive(false);
    }

    public void Potion()
    {
        sword.color = sw;
        secondary.color = snd;
        third.color = trd;
        potion.color = new Color(pot.r + 0.2f, pot.g + 0.2f, pot.b + 0.2f);
        bendages.color = ben;
        weapon1.SetActive(false);
        weapon2.SetActive(false);
        weapon3.SetActive(false);
        item1.SetActive(true);
        item2.SetActive(false);
    }
    public void Bendages()
    {
        sword.color = sw;
        secondary.color = snd;
        third.color = trd;
        potion.color = pot;
        bendages.color = new Color(ben.r + 0.2f, ben.g + 0.2f, ben.b + 0.2f);
        weapon1.SetActive(false);
        weapon2.SetActive(false);
        weapon3.SetActive(false);
        item1.SetActive(false);
        item2.SetActive(true);
    }


    public bool CheckPlaying() {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Eating") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("sword_att") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("YourAnimationName")) //manca arma secondaria
            return true;
        return false;
    }
}
