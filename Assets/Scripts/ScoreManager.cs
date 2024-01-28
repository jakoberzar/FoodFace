using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public Score scoreComponent;
    public Health healthComponent;
    public float startingTimeWithoutDecrease = 2.0f;

    int score = 0;
    float health = 100;

    public void AddScore(int points)
    {
        score += points;
        scoreComponent.SetScore(score);
        AddHealth(points);
    }

    public void AddHealth(float add)
    {
        Debug.Log("Adding " + add + " to " + health);
        health += add;
        health = Mathf.Clamp(health, 0, 100);
        Debug.Log("Result is " + health);
        healthComponent.SetHealth(health);
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
    }
}
