using System;
using Code.Services.ScoreService;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.UI
{
    public class ScoreView : Overlay
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void OnScoreChanged(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}