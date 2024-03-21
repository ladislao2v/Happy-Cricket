using Code.Services.AchievementsService;
using Code.Services.Factories.AchievementViewFactory;
using Zenject;

namespace Code.UI.Achievements
{
    public class AchievementsOverlay : Overlay
    {
        private IAchievementViewFactory _achievementViewFactory;
        private IAchievementsService _achievementsService;

        [Inject]
        private void Construct(IAchievementsService achievementsService, IAchievementViewFactory achievementViewFactory)
        {
            _achievementsService = achievementsService;
            _achievementViewFactory = achievementViewFactory;
        }

        private void OnEnable()
        {
            foreach (var achievement in _achievementsService.OpenedAchievements)
            {
                _achievementViewFactory.Create(achievement, transform);
            }
        }
    }
}