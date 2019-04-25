using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject player;
    public GameObject inventory;
    public GameObject healthBar;
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        player.SetActive(true);
        inventory.SetActive(true);
        healthBar.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        player.SetActive(false);
        inventory.SetActive(false);
        healthBar.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Quit()
    {
        Debug.Log("Termina partita");
        Application.Quit();
    }

    public void Save()
    {
        string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory() + "/Assets/Scenes/Calaris");
        foreach (string filename in filePaths)
        {
            //Do your job with "file"
            FileInfo fi = new FileInfo(filename);
            string str = Directory.GetCurrentDirectory() + "/Assets/Scenes/Save/Save" + fi.Name;
            //if (!File.Exists(str))
            //{
                File.Copy(filename, str, true);
            //}
            Debug.Log(filename);
            Debug.Log(str);
        }

    }
}
