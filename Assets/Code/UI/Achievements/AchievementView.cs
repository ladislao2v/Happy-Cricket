using Code.Services.AchievementsService;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Achievements
{
    public class AchievementView : MonoBehaviour, IAchievementView
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Image _logo;
        public void Construct(IAchievementConfig config)
        {
            _nameText.text = config.Name;
            _scoreText.text = $"{config.Score}";
            _logo.sprite = config.Sprite;
        }
    }
}