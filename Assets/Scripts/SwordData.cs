using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SwordData {

    public int level;
    public int damage;

    public SwordData(Sword sword)
    {
        level = sword.level;
        damage = sword.damage;
    }
}
