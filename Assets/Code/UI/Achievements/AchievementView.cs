using Code.Services.AchievementsService;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Achievements
{
    public class AchievementView : MonoBehaviour, IAchievementView
    {
        [SerializeField] private Image _logo;

        public void Construct(IAchievementConfig config, bool isOpen)
        {
            _logo.sprite = isOpen ? config.OpenSprite : config.CloseSprite;
        }
    }
}