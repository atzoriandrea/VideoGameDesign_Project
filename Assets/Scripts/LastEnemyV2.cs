using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastEnemyV2 : MonoBehaviour {

    public int level;
    public float health;


    public void SaveLastEnemyV2()
    {
        SaveSystem.SaveLastEnemyV2(this);
    }

    public void LoadLastEnemyV2()
    {
        LastEnemyData data = SaveSystem.LoadLastEnemyV2();
        level = data.level;
        health = data.health;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;
    }
}
