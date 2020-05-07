using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public int score = 0;

    public void AddScore(int points)
    {
        score += points;
    }

    public int getScore() => score;


    public static void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
        instance.score = 0;
    }


    public static void CloseGame()
    {
        //ignored inside editor
        Application.Quit();
    }


    void Awake()
    {
        //singleton
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
