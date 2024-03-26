using TMPro;
using UnityEngine;

namespace Code.Services.AchievementsService
{
    [CreateAssetMenu(menuName = "Create AchievementConfig", fileName = "AchievementConfig", order = 0)]
    public class AchievementConfig : ScriptableObject, IAchievementConfig
    {
        [field: SerializeField] public int Score { get; private set; }
        [field: SerializeField] public Sprite OpenSprite { get; private set; }
        [field: SerializeField] public Sprite CloseSprite { get; private set; }
    }
}