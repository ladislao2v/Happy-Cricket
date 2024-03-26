using System.Collections.Generic;
using Code.Services.SaveLoadDataService;
using Code.Services.ScoreService;

namespace Code.Services.AchievementsService
{
    public interface IAchievementsService
    {
        IReadOnlyDictionary<IAchievementConfig, bool> OpenedAchievements { get; }
        void Load(int score);
    }
}