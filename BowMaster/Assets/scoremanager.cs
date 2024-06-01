using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoremanager : MonoBehaviour
{
    public static int Score = 0;
    public static int lastScore = 0;
    public static string message = "";
    public static string x = "";

    public TextMeshPro scoreText3D;
    public TextMeshPro scoreText3D_2;
    public TextMeshPro scoreText3D_3;

    void Start()
    {
        if (scoreText3D == null)
        {
            Debug.LogError("Score Text is not assigned!");
            return;
        }

        if (scoreText3D_2 == null)
        {
            Debug.LogError("Score Text is not assigned!");
            return;
        }

        if (scoreText3D_3 == null)
        {
            Debug.LogError("Score Text is not assigned!");
            return;
        }
        UpdateScoreText();
    }

    void Update()
    {
        UpdateScoreText();
    }

    public static void AddScore(int points)
    {
        Score += points;
    }

    public static void AddMessage(string str)
    {
        message = str;
        Debug.Log("Current Score: " + message);
    }

    public static void hint(string str)
    {
        x = str;
        Debug.Log("Current Score: " + x);
    }

    public void UpdateHint(string str)
    {
        x = str;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText3D != null)
        {
            scoreText3D.text ="" + Score;
        }

        if (scoreText3D_2 != null)
        {
            scoreText3D_2.text = message;
        }

        if (scoreText3D_3 != null)
        {
            scoreText3D_3.text = x;
        }
    }
}
