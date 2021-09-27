using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUIHandler : MonoBehaviour
{
    int score;
    TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = FindObjectOfType<TextMeshProUGUI>();
    }

    public void ScoreBoard(int updatedScore)
    {
        score += updatedScore;
        scoreText.text = score.ToString();
    }
}
