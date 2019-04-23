using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    private int selected;
    Image sword, secondary, potion, bendages;
    public GameObject weapon1, weapon2, item1, item2;
    UnityEngine.Color sw, snd, pot, ben;
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
        if (Input.GetKeyDown("1")) {
            selected = 1;
            Sword();
        }
        if (Input.GetKeyDown("2")) { 
            selected = 2;
            SecondWeapon();
        }
        if (Input.GetKeyDown("3"))
        {
            selected = 3;
            Potion();
        }
        selected = 3;
        if (Input.GetKeyDown("4"))
        {
            selected = 4;
            Bendages();
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
}
