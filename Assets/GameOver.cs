using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*In questa classe viene gestita la scena successiva alla morte del player.*/

public class GameOver : MonoBehaviour {

    public GameObject Canvas;
    public Player player;
    private Animator anim;
    public GameObject giocatore;
    public GameObject win;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        //Quando il giocatore muore, viene attivato un trigger che avvia l'animazione per l'apparizione della schermata di gameover
		if(player.health <= 0f )
        {
            win.SetActive(false);
            Canvas.SetActive(false);
            anim.SetTrigger("GameOver");
            giocatore.SetActive(false);

        }
    }
    //Una volta comparsa la schermata, può decidere di ripartire dall'ultimo salvataggio o terminare la partita e tornare al menu principale.
    public void LoadGame()
    {
        win.SetActive(true);
        Canvas.SetActive(true);
        anim.ResetTrigger("GameOver");
        anim.SetTrigger("load");
    }

    public void TerminaPartita()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //Torna al menu principale.
    }

}
