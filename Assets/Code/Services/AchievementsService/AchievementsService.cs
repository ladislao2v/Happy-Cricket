using System;
using System.Collections.Generic;
using Code.Services.SaveLoadDataService;
using Code.Services.StaticDataService;

namespace Code.Services.AchievementsService
{
    public class AchievementsService : IAchievementsService
    {
        private readonly IAchievementConfig[] _achievements;
        private readonly List<IAchievementConfig> _openedAchievements = new();
        
        public IReadOnlyList<IAchievementConfig> OpenedAchievements => _openedAchievements;

        public AchievementsService(IStaticDataService staticDataService) => 
            _achievements = staticDataService.GetAchievements();

        public void OnScoreChanged(int score)
        {
            foreach (IAchievementConfig achievementConfig in _achievements)
            {
                if(score > achievementConfig.Score)
                    _openedAchievements.Add(achievementConfig);
            }
        }

        public void LoadData(ISaveLoadDataService saveLoadDataService)
        {
            var opened = saveLoadDataService
                .LoadByCustomKey<List<IAchievementConfig>>(nameof(OpenedAchievements));
            
            opened.ForEach(x => _openedAchievements.Add(x));
        }

        public void SaveData(ISaveLoadDataService saveLoadDataService) => 
            saveLoadDataService.SaveByCustomKey(_openedAchievements, nameof(OpenedAchievements));
    }
}