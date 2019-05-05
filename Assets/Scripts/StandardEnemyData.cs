using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StandardEnemyData {



    public int level;
    public float health;
    public float[] position;

    public StandardEnemyData(StandardEnemy enemy)
    {
        level = enemy.level;
        health = enemy.health;

        position = new float[3];
        position[0] = enemy.transform.position.x;
        position[1] = enemy.transform.position.y;
        position[2] = enemy.transform.position.z;
    }

}
