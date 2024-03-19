using TMPro;
using UnityEngine;

namespace Code.UI
{
    public class ScoreView : Overlay, IScoreView
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void OnScoreChanged(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}