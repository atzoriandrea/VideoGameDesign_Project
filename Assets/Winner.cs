using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script utilizzato per gestire la scena della vittoria dopo l'uccisione dell'ultimo Boss
public class Winner : MonoBehaviour {


    public GameObject Canvas;
    private Animator anim;
    public GameObject giocatore;
    public LastEnemyV2 lastEnemy;
    public GameObject gameOver;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Una volta morto il secondo boss, viene attivato un trigger che fa comparire la schermata di vittoria.
        if (lastEnemy.health <= 0f)
        {
            gameOver.SetActive(false);
            Canvas.SetActive(false);
            anim.SetTrigger("Winner");
            giocatore.SetActive(false);

        }
    }

    public void TerminaPartita()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //torna al menu principale.
    }


}
