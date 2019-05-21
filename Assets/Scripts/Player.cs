using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int level;
    public float health;
    public float maxHealth;
    public float experience;
    public float limitExperience;
    public float arrow;
    public int apples;
    public int potions;
    
    public Text testoLivello;

    public bool[] keys = { false, false, false };

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        level = data.level;
        health = data.health;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        experience = data.experience;
        limitExperience = data.limitExperience;
        arrow = data.arrow;
        apples = data.apples;
        potions = data.potions;
        maxHealth = data.maxHealth;
        keys = data.keys;

        transform.position = position;
    }
    private void Update()
    {
        testoLivello.GetComponent<Text>().text = level.ToString();
    }
}
