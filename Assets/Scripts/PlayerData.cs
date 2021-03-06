﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Classe utilizzata per ilsalvataggio dei dati del  player.
[System.Serializable] //Rende i campi di questa classe serializzabili
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
    public bool[] keys;

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
        keys = player.keys;


        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
