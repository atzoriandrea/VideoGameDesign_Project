using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Rende i campi di classe serializzabili
public class SwordData {

    public int level;
    public int damage;

    public SwordData(Sword sword)
    {
        level = sword.level;
        damage = sword.damage;
    }
}
