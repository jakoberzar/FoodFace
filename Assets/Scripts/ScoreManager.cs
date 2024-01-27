using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Health healthScript;

    int score = 0;
    float health = 100;


    public void AddScore(int points)
    {
        score += points;
        AddHealth(points);
        scoreText.text = "Score: " + score;
    }

    public void DecreaseScore(int points)
    {
        score -= points;
        //AddHealth(-points);
        scoreText.text = "Score: " + score;
    }

    void AddHealth(float add)
    {
        health += add;
        health = Mathf.Min(health, 100);
        healthScript.SetHealth(health);
    }



    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        AddHealth(-12 * Time.deltaTime);
    }
}
