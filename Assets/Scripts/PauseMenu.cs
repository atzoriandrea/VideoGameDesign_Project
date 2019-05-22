using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject player;
    public GameObject ViewFinder;
    public GameObject inventory;
    public GameObject healthBar;
    public AudioSource myAudio;
    public GameObject comandi, gameover, win;
    public Slider Volume;
    // Update is called once per frame
    void Update()
    {

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
        gameover.SetActive(true);
        win.SetActive(true);
        pauseMenuUI.SetActive(false);
        player.SetActive(true);
        inventory.SetActive(true);
        healthBar.SetActive(true);
        ViewFinder.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause()
    {
        gameover.SetActive(false);
        win.SetActive(false);
        comandi.SetActive(false);
        pauseMenuUI.SetActive(true);
        player.SetActive(false);
        inventory.SetActive(false);
        ViewFinder.SetActive(false);
        healthBar.SetActive(false);
        gameover.SetActive(false);
        win.SetActive(false);
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
        }

    }


}
