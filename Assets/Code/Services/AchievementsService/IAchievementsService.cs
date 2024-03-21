using System.Collections.Generic;
using Code.Services.SaveLoadDataService;
using Code.Services.ScoreService;

namespace Code.Services.AchievementsService
{
    public interface IAchievementsService : ILoadable, ISavable
    {
        IReadOnlyList<IAchievementConfig> OpenedAchievements { get; }
        void OnScoreChanged(int score);
    }
}