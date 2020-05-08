using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    bool isPaused = false;
    GameObject player;

    public GameObject pauseMenu;

    public bool IsPaused() => isPaused;
    public void SetIsPaused(bool value) => isPaused = value;

    void Start() 
    {
        player = GameObject.Find("PlayerShip"); 
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (isPaused)
            {
                Resume();
                isPaused = false;
            }
            else 
            {
                Pause();
                isPaused = true;
            }
        }

    }

    void Resume() 
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        if (player != null) player.GetComponent<PlayerController>().enabled = true;
    }

    void Pause() 
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        if (player != null) player.GetComponent<PlayerController>().enabled = false;
    }
}
