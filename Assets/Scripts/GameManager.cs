using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }


    public void CloseGame()
    {
        //ignored inside editor
        Application.Quit();
    }


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

  
}
