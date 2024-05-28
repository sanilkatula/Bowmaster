using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoremanager : MonoBehaviour
{
    public static int Score = 0;
    public TextMeshPro scoreText3D;

    void Start()
    {
        if (scoreText3D == null)
        {
            Debug.LogError("Score Text is not assigned!");
            return;
        }

        UpdateScoreText();
    }

    void Update()
    {
        if (scoreText3D != null)
        {
            UpdateScoreText();
        }
    }

    public static void AddScore(int points)
    {
        Score += points;
        Debug.Log("Current Score: " + Score);
    }

    void UpdateScoreText()
    {
        if (scoreText3D != null)
        {
            scoreText3D.text = "Score: " + Score;
        }
    }
}

