using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFirst : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject enemy;
    int generated;
    int x = 201;
    int z = 755;
    void Start()
    {
        generated = 0;
    }
    void Update()
    {
        if (enemy == null && generated < 5)
        {
            enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.position = new Vector3(x, 1, z);
            generated++;
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
        }
        else if (generated < 5)
        {
            enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.position = new Vector3(++x, 1, ++z);
            generated++;
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
        }
    }
}