using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemy : MonoBehaviour {
    public GameObject prefab;
    public int level;
    public float health;


    public void SaveEnemy()
    {
        int i = 0;
        StandardEnemy[] enemies = FindObjectsOfType<StandardEnemy>();
        foreach (StandardEnemy enemy in enemies)
        {
            SaveSystem.SaveStandardEnemy(enemy, i);
            i++;
        }
    }

    public void InvokeLoad()
    {
        StandardEnemy[] enemies = FindObjectsOfType<StandardEnemy>();
        Debug.Log("Nemici trovati : " + enemies.Length);
        foreach(StandardEnemy enemy in enemies)
        {
            Destroy(GameObject.Find("enemy"));
        }
        SaveSystem.LoadStandardEnemy();
        
    }
    public void LoadEnemy( StandardEnemyData data)
    {
        GameObject enemy;
        Debug.Log("Prefab name: " + prefab.name);
        enemy = Instantiate(prefab) as GameObject;
        level = data.level;
        health = data.health;
        enemy.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
    }
}
