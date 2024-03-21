using UnityEngine;

namespace Code.Services.AchievementsService
{
    public interface IAchievementConfig
    {
        int Score { get; }
        string Name { get; }
        Sprite Sprite { get; }
    }
}