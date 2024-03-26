using System.Collections.Generic;
using System.Linq;
using Code.Services.StaticDataService;

namespace Code.Services.AchievementsService
{
    public class AchievementsService : IAchievementsService
    {
        private readonly Dictionary<IAchievementConfig, bool> _openedAchievements = new();

        public IReadOnlyDictionary<IAchievementConfig, bool> OpenedAchievements => _openedAchievements;

        public AchievementsService(IStaticDataService staticDataService)
        {
            var achievements = staticDataService.GetAchievements();

            var sortedAchievements = 
                achievements.OrderBy(x => x.Score);
            
            foreach (var achievement in sortedAchievements)
            {
                _openedAchievements.Add(achievement, false);
            }
        }

        public void Load(int score)
        {
            foreach (var achievement in _openedAchievements.Keys)
            {
                if (score > achievement.Score)
                    _openedAchievements[achievement] = true;
            }
        }

    }
}
