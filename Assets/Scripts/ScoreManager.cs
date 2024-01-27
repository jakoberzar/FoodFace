using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    int score = 0;


    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void DecreaseScore(int points)
    {
        score -= points;
        scoreText.text = "Score: " + score;
    }

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
