using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        //Quando l'utente preme il tasto esc, si entra o si esce dal menù principale.
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

    //In queste funzioni vengono gestiti tutti i pulsanti presenti nel menu di pausa.
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

    //Quando il gioco è in pausa vengono disattivati o attivati diversi game object per evitare collisioni all'interno del canvas.
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //torna al menu principale
    }


}
