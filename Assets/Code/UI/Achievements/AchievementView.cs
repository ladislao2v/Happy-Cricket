using Code.Services.AchievementsService;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Achievements
{
    public class AchievementView : MonoBehaviour, IAchievementView
    {
        [SerializeField] private Image _logo;
        public void Construct(IAchievementConfig config)
        {
            _logo.sprite = config.Sprite;
        }
    }
}