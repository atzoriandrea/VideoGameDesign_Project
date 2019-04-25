using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int level;
    public float health;

    public Player(int level, float health)
    {
        this.level = level;
        this.health = health;
    }
}
