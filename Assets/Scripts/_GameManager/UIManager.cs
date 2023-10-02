using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SpaceWar3D
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private TextMeshProUGUI startHighScoreText;
        [SerializeField] private TextMeshProUGUI endHighScoreText;
        [SerializeField] private TextMeshProUGUI endscoreText;

        private void Start()
        {
            startHighScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }

        public void UpdateHighScore(int highScore)
        {
            endHighScoreText.text = "High Score: " + highScore;
        }

        public void ShowScore(int score)
        {
            endscoreText.text = "Score: " + score;
        }
        
        
    }
}

