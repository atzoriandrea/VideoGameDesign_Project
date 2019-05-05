using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastEnemy : MonoBehaviour {

    public int level;
    public float health;


    public void SaveLastEnemy()
    {
        SaveSystem.SaveLastEnemy(this);
    }

    public void LoadLastEnemy()
    {
        LastEnemyData data = SaveSystem.LoadLastEnemy();
        level = data.level;
        health = data.health;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;
    }
}
