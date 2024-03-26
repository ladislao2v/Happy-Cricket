using UnityEngine;

namespace Code.Services.AchievementsService
{
    public interface IAchievementConfig
    {
        int Score { get; }
        Sprite OpenSprite { get; }
        Sprite CloseSprite { get; }
    }
}