using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    bool isPaused = false;

    public bool IsPaused() => isPaused;
    public void SetIsPaused(bool value) => isPaused = value;

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            isPaused = !isPaused;
            Time.timeScale = (Time.timeScale + 1) % 2;
        }

    }
}
