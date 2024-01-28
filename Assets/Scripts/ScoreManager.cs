using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public Score scoreComponent;
    public Health healthComponent;
    public GameObject endOverlay;
    public TextMeshProUGUI endScoreText;
    public float startingTimeWithoutDecrease = 2.0f;
    public bool isRunning => _isRunning;

    private bool _isRunning = true;
    int score = 0;
    float health = 100;

    public void AddScore(int points)
    {
        if (!isRunning) return;
        score += points;
        scoreComponent.SetScore(score);
        AddHealth(points / 2);
    }

    public void AddHealth(float add)
    {
        if (!isRunning) return;
        health += add;
        health = Mathf.Clamp(health, 0, 100);
        healthComponent.SetHealth(health);
    }

    void Start()
    {
        endOverlay.SetActive(false);
        _isRunning = true;
    }

    void Update()
    {
        if (startingTimeWithoutDecrease > 0)
        {
            startingTimeWithoutDecrease -= Time.deltaTime;
        }
        else
        {
            AddHealth(-15 * Time.deltaTime);
        }
        if (health <= 0 && isRunning)
        {

            int highScore = PlayerPrefs.GetInt("highScore");
            if (highScore == 0)
            {
                endScoreText.text = "Your final score was " + score + ".";
                PlayerPrefs.SetInt("highScore", score);
            }
            else if (score > highScore)
            {
                endScoreText.text = "Congratulations! You have just beaten the high score of " + highScore + "!\nYour score of " + score + " is now the new record!";
                highScore = score;
                PlayerPrefs.SetInt("highScore", score);
            }
            else
            {
                endScoreText.text = "Your final score was " + score + ",\ntry to beat the high score of " + highScore + "!";
            }
            endOverlay.SetActive(true);
            _isRunning = false;
        }
    }


    //// Singleton
    //private static ScoreManager _instance;
    //public static ScoreManager Instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //        {
    //            Debug.LogError("Score manager is null");
    //        }
    //        return _instance;
    //    }
    //}
    //private void Awake()
    //{
    //    _instance = this;
    //}
}
