﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
		if(player.health <= 0f )
        {
            win.SetActive(false);
            Canvas.SetActive(false);
            anim.SetTrigger("GameOver");
            giocatore.SetActive(false);

        }
    }

    public void LoadGame()
    {
        win.SetActive(true);
        Canvas.SetActive(true);
        anim.ResetTrigger("GameOver");
        anim.SetTrigger("load");
    }

    public void TerminaPartita()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
