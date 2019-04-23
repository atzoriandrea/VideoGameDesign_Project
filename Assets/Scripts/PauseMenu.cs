using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject player;
    public GameObject inventory;
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
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        player.SetActive(false);
        inventory.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Quit()
    {
        Debug.Log("Termina partita");
        Application.Quit();
    }
}
