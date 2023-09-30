using System;
using System.Collections;
using System.Collections.Generic;
using SpaceWar3D;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int highScore;
    [SerializeField] private int finalScore;
    [SerializeField] private int additionalScore;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private PlayerHealth playerHealth;

    private void OnEnable()
    {
        EnemyHealth.OnGetScore += AddScore;
        playerHealth.onSaveScore += SaveScore;
    }

    private void OnDisable()
    {
        EnemyHealth.OnGetScore -= AddScore;
        playerHealth.onSaveScore -= SaveScore;
    }

    private void Start()
    {
        Debug.Log("HighScore: " + PlayerPrefs.GetInt("HighScore"));
        finalScore = 0;
    }

    private void Update()
    {
        scoreText.text = score.ToString();
    }

    private void AddScore()
    {
        score += additionalScore;
    }

    public void SaveScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        Debug.Log("HighScore after game: " + PlayerPrefs.GetInt("HighScore"));

    }
}
