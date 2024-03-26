using Code.Services.AchievementsService;
using Code.UI.Achievements;
using UnityEngine;

namespace Code.Services.Factories.AchievementViewFactory
{
    public interface IAchievementViewFactory
    {
        IAchievementView Create(IAchievementConfig config, bool isOpen, Transform parent);
    }
}