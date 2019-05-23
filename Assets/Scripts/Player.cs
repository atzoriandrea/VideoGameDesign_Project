using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Classe dedicata al giocatore, gestisce il salvataggio e il caricamento di tutte i suoi dati.
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
    //Salvataggio giocatore
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    //Caricamento giocatore
    public void LoadPlayer()
    {
        //Il tipo player data viene deserializzato al caricamento e viene ripopolato il giocatore coi dati all'ultimo salvataggio
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


    //Aggiorna l'indicatore del livello

    private void Update()
    {
        testoLivello.GetComponent<Text>().text = level.ToString(); //stampa il livello del player nel canvas principale.
    }
}
