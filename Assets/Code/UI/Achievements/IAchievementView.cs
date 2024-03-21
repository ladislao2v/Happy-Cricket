using Code.Services.AchievementsService;

namespace Code.UI.Achievements
{
    public interface IAchievementView
    {
        void Construct(IAchievementConfig config);
    }
}