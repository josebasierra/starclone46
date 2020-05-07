using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    int score;

    // Update is called once per frame
    void Update()
    {
     	score = GameManager.instance.getScore();
        
        print();
    }

    private void print() 
    {
    	if (score < 10) text.text = "000"+ score.ToString();
        else if (score < 100) text.text = "00"+ score.ToString();
        else if (score < 1000)text.text = "0"+ score.ToString();
        else text.text = score.ToString();
    } 
}
