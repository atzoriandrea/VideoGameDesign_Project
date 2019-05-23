using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Classe che gestisce il danno e il livello della spada, con le funzioni di salvataggioe caricamento.
public class Sword : MonoBehaviour {

    public int level;
    public int damage;


    public void SaveSword()
    {
        SaveSystem.SaveSword(this);
    }

    public void LoadSword()
    {
        SwordData data = SaveSystem.LoadSword();
        level = data.level;
        damage = data.damage;
    }
}
