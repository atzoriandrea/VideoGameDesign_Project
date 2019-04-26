using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Animations;

public class Inventory : MonoBehaviour {
    private int selected;

    Image sword, secondary, potion, bendages;
    public GameObject weapon1, weapon2, item1, item2;
    UnityEngine.Color sw, snd, pot, ben;
    public Animator anim;

    // Use this for initialization
    void Start () {
        selected = 1;
        sword = GameObject.Find("Sword").GetComponent<Image>();
        sw = sword.color;
        secondary = GameObject.Find("SecondWeapon").GetComponent<Image>();
        snd = secondary.color;
        potion = GameObject.Find("Potions").GetComponent<Image>();
        pot = potion.color;
        bendages = GameObject.Find("Bendages").GetComponent<Image>();
        ben = bendages.color;

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("1")  && !CheckPlaying()) {
            selected = 1;
            Sword();
        }
        if (Input.GetKeyDown("2") && !CheckPlaying()) { 
            selected = 2;
            SecondWeapon();
        }
        if (Input.GetKeyDown("3") && !CheckPlaying())
        {
            selected = 3;
            Potion();
        }
        if (Input.GetKeyDown("4") && !CheckPlaying())
        {
            selected = 4;
            Bendages();
        }
        if (Input.GetButton("Fire1") && selected == 1)
        {
            anim.SetTrigger("swordattack");

        }
        if ((selected == 3 || selected == 4 )&& Input.GetButton("Fire1")) {      
           anim.SetTrigger("heal");
        }
    }

    public void Sword()
    {
        sword.color = new Color(sw.r + 0.2f, sw.g + 0.2f, sw.b + 0.2f);
        secondary.color = snd;
        potion.color = pot;
        bendages.color = ben;
        weapon1.SetActive(true);
        weapon2.SetActive(false);
        item1.SetActive(false);
        item2.SetActive(false);
    }
    public void SecondWeapon()
    {
        sword.color = sw;
        secondary.color = new Color(snd.r + 0.2f, snd.g + 0.2f, snd.b + 0.2f);
        potion.color = pot;
        bendages.color = ben;
        weapon1.SetActive(false);
        weapon2.SetActive(true);
        item1.SetActive(false);
        item2.SetActive(false);
    }
    public void Potion()
    {
        sword.color = sw;
        secondary.color = snd;
        potion.color = new Color(pot.r + 0.2f, pot.g + 0.2f, pot.b + 0.2f);
        bendages.color = ben;
        weapon1.SetActive(false);
        weapon2.SetActive(false);
        item1.SetActive(true);
        item2.SetActive(false);
    }
    public void Bendages()
    {
        sword.color = sw;
        secondary.color = snd;
        potion.color = pot;
        bendages.color = new Color(ben.r + 0.2f, ben.g + 0.2f, ben.b + 0.2f);
        weapon1.SetActive(false);
        weapon2.SetActive(false);
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
