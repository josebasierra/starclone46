using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject winMenu;

    bool isPaused = false;
    bool inWinMenu = false;
    GameObject player;



    public bool IsPaused() => isPaused;

    public void SetIsPaused(bool value) => isPaused = value;

    //TODO: update text score with score obtained
    public void ViewWinMenu()
    {
        if (player != null) player.GetComponent<Health>().SetGodMode(true);
        inWinMenu = true;
        pauseMenu.SetActive(false);
        winMenu.SetActive(true);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        if (player != null) player.GetComponent<PlayerController>().enabled = true;
        isPaused = false;
    }


    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        if (player != null) player.GetComponent<PlayerController>().enabled = false;
        isPaused = true;
    }


    void Start() 
    {
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        player = GameObject.Find("PlayerShip"); 
    }

    void Update()
    {
        if (inWinMenu) return;

        if (Input.GetKeyDown("escape"))
        {
            if (isPaused) Resume();
            else Pause();
        }
    }



}
