using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameObject Canvas;
    public Player player;
    private Animator anim;
    private Animator playerAnimator;
    public GameObject giocatore;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerAnimator = giocatore.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
		if(player.health <= 0f)
        {

            Canvas.SetActive(false);
            anim.SetTrigger("GameOver");
            anim.SetBool("GameOver", true);
            giocatore.SetActive(false);

        }
    }

    public void LoadGame()
    {
        Canvas.SetActive(true);
        anim.SetTrigger("load");
    }

    public void TerminaPartita()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
