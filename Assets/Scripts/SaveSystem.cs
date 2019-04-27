using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

public static class SaveSystem {

	public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path =  Application.persistentDataPath + "/Player/player.fun";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveLastEnemy(LastEnemy enemy)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/LastEnemy/lastEnemy.fun";

        FileStream stream = new FileStream(path, FileMode.Create);

        LastEnemyData data = new LastEnemyData(enemy);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveStandardEnemy(StandardEnemy enemy, int i)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/StandardEnemy/enemy"+ i +".fun";

        FileStream stream = new FileStream(path, FileMode.Create);

        StandardEnemyData data = new StandardEnemyData(enemy);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/Player/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = (PlayerData)formatter.Deserialize(stream);
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("SAVE FILE NOT FOUND IN : " + path);
            return null;
        }
    }

    public static LastEnemyData LoadLastEnemy()
    {
        string path = Application.persistentDataPath + "/LastEnemy/lastEnemy.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LastEnemyData data = (LastEnemyData)formatter.Deserialize(stream);
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("SAVE FILE NOT FOUND IN : " + path);
            return null;
        }
    }

    public static void LoadStandardEnemy()
    {
        int i;
        string[] filePaths = Directory.GetFiles(Application.persistentDataPath + "/StandardEnemy");
        foreach(string file in filePaths)
        {
            Debug.Log(file);
        }
        if (filePaths != null)
        {
            for (i = filePaths.Length-1; i >= 0; i--)
            {
                Debug.Log("Qui arrivo: " + i);
                string path = Application.persistentDataPath + "/StandardEnemy/enemy" + i + ".fun";
                if (File.Exists(path))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    FileStream stream = new FileStream(path, FileMode.Open);

                    StandardEnemyData data = (StandardEnemyData)formatter.Deserialize(stream);
                    stream.Close();
                    StandardEnemy enemy = new GameObject("StandardEnemy").AddComponent<StandardEnemy>();
                    enemy.LoadEnemy(data);

                }
                else
                {
                    Debug.Log("SAVE FILE NOT FOUND IN : " + path);
                }
            }
        }
    }
}
