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
        player = GameObject.FindGameObjectWithTag("Player"); //para desactivar el script "Crosshair"
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (isPaused) Resume(); 
            else Pause();

            isPaused = !isPaused;
        }

    }

    void Resume() 
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponent<Crosshair>().enabled = true;
    }

    void Pause() 
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        player.GetComponent<Crosshair>().enabled = false;
    }
}
