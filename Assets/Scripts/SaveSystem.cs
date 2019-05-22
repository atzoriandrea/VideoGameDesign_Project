using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

public static class SaveSystem {
    /*Nella funzione SavePlayer viene creato un file in formato binario dove verranno salvati tutti i dati del giocatore,
    del boss di primo livello e del boss di secondo livello, tramite degli oggetti serializzabili. 
    tramite il persistent data path, i salvataggi verranno caricati nella directory prncipale, la quale esisterà sempre,
    non ci sarà bisogno di dare un path differente a seconda della piattaforma utilizzata.*/
	public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path =  Application.persistentDataPath + "player.fun";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SaveSword(Sword sword)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "sword.fun";

        FileStream stream = new FileStream(path, FileMode.Create);

        SwordData data = new SwordData(sword);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveLastEnemy(LastEnemy enemy)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "lastEnemy.fun";

        FileStream stream = new FileStream(path, FileMode.Create);

        LastEnemyData data = new LastEnemyData(enemy);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveLastEnemyV2(LastEnemyV2 enemy)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "lastEnemyV2.fun";

        FileStream stream = new FileStream(path, FileMode.Create);

        LastEnemyV2Data data = new LastEnemyV2Data(enemy);

        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "player.fun";
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
    public static SwordData LoadSword()
    {
        string path = Application.persistentDataPath + "sword.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SwordData data = (SwordData)formatter.Deserialize(stream);
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
        string path = Application.persistentDataPath + "lastEnemy.fun";
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

public static LastEnemyData LoadLastEnemyV2()
{
    string path = Application.persistentDataPath + "lastEnemyV2.fun";
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
}
