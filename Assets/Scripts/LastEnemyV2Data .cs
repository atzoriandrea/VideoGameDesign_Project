using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Questa classe viene utilizzata per il salvataggio del boss di secondo livello,
  vengono salvati tutti i suoi fields tramite questa classe in un file binario*/
[System.Serializable] //Tag che rende i campi di questa classe serializzabili
public class LastEnemyV2Data{

    public int level;
    public float health;
    public float[] position;

    public LastEnemyV2Data(LastEnemyV2 enemy)
    {
        level = enemy.level;
        health = enemy.health;

        position = new float[3];
        position[0] = enemy.transform.position.x;
        position[1] = enemy.transform.position.y;
        position[2] = enemy.transform.position.z;
    }

}

