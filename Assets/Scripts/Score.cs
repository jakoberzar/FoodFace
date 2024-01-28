using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int score = 0;

    public void SetScore(int score)
    {
        this.score = score;
        scoreText.text = "Score: " + score;
    }
}
