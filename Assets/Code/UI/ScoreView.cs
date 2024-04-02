using System;
using TMPro;
using UnityEngine;

namespace Code.UI
{
    public class ScoreView : Overlay, IScoreView
    {
        [SerializeField] private TextMeshProUGUI[] _scoreTexts;
        [SerializeField] private TextMeshProUGUI _allText;
        [SerializeField] private TextMeshProUGUI _target;
        
        private int _index = 0;

        private void Start()
        {
            _index = 0;
            _allText.text = 0.ToString();
        }

        public event Action OnHalf;
        public event Action OnFinish;

        public void SetTarget(int target)
        {
            _target.text = $"TARGET {target}";
        }
        
        public void OnScoreChanged(int points, int score)
        {
            _scoreTexts[_index++].text = points.ToString();

            if(_index == 3)
                OnHalf?.Invoke();
            else if(_index == 6)
                OnFinish?.Invoke();

            _allText.text = score.ToString();
            
            if(points == 0)
                _scoreTexts[_index-1].text = "x";
            
            Debug.Log($"Current score cell {_index} and it value is {_scoreTexts[_index-1].text}");
        }
    }
}