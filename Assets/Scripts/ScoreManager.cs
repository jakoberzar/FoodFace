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

    bool isRunning = true;
    int score = 0;
    float health = 100;

    public void AddScore(int points)
    {
        if (!isRunning) return;
        score += points;
        scoreComponent.SetScore(score);
        AddHealth(points);
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
        isRunning = true;
    }

    void Update()
    {
        if (startingTimeWithoutDecrease > 0)
        {
            startingTimeWithoutDecrease -= Time.deltaTime;
        }
        else
        {
            AddHealth(-12 * Time.deltaTime);
        }
        if (health <= 0)
        {
            endScoreText.text = "Your final score was " + score + ".";
            endOverlay.SetActive(true);
            isRunning = false;
        }
    }
}
