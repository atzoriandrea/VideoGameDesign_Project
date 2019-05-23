using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
//Gestione dei pulsanti del menù principale.
public class MenuScript : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Cambio scena seguendo l'id datò nella build settings.
    }

    public void QuitGame()
    {
        Application.Quit(); //Chiude l'applicazione.
    }
}
