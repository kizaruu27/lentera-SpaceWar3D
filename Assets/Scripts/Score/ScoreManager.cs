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
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreTxt; 

    [SerializeField] private int additionalScore;

    private void OnEnable()
    {
        EnemyHealth.OnGetScore += AddScore;
        PlayerHealth.onSaveScore += SetHighScore;
    }

    private void OnDisable()
    {
        EnemyHealth.OnGetScore -= AddScore;
        PlayerHealth.onSaveScore -= SetHighScore;
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Update()
    {
        scoreText.text = score.ToString();
        highScoreTxt.text = "HighScore: " + highScore;
    }

    private void AddScore()
    {
        if (!PlayerHealth.isDead)
            score += additionalScore;
    }

    public void SetHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        
        GetHighScore();
    }

    void GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        Debug.Log($"HIGHSCORE: {highScore}");
    }
}
