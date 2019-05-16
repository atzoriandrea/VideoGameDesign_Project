using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int level;
    public float health;
    public float maxHealth;
    public float[] position;
    public float experience;
    public float limitExperience;
    public float arrow;
    public int apples;
    public int potions;

    public PlayerData(Player player)
    {
        level = player.level;
        health = player.health;
        experience = player.experience;
        limitExperience = player.limitExperience;
        arrow = player.arrow;
        apples = player.apples;
        potions = player.potions;
        maxHealth = player.maxHealth;
        

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
