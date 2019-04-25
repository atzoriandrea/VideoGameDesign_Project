using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public void PlayGame()
    {
        Debug.Log((SceneManager.GetActiveScene().buildIndex + 1).ToString());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        string path = Directory.GetCurrentDirectory() + "/Assets/Scenes/Save/SaveCalaris.unity";
        if (!File.Exists(path))
        {
            Debug.Log("You don't have scenes to load");
        }
        else
        {
            SceneManager.LoadScene("SaveCalaris");
        }
    }
}
