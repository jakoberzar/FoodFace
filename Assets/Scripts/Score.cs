using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;
    public TextMeshPro scoreText;

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void DecreaseScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

}
