using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public int highScore;
    public int count;
    public int lives=2;
    private Text scoreText;
    private GameObject brickParent;
   
    void Start()
    {
         brickParent = GameObject.FindGameObjectWithTag("BrickParent");
         count = brickParent.transform.childCount; 
    }
    void Update()
    {
        if (count>brickParent.transform.childCount)
         {
            score += 10;
            scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
            scoreText.text = $"{score}";
            count--;
        }
    }
    
}
