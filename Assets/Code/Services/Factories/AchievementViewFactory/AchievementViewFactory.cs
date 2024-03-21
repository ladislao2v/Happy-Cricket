using Code.Services.AchievementsService;
using Code.UI.Achievements;
using UnityEngine;

namespace Code.Services.Factories.AchievementViewFactory
{
    public class AchievementViewFactory : IAchievementViewFactory
    {
        private readonly AchievementView _prefab;

        public AchievementViewFactory(AchievementView prefab)
        {
            _prefab = prefab;
        }
        
        public IAchievementView Create(IAchievementConfig config, Transform parent)
        {
            var view = Object.Instantiate<AchievementView>(_prefab, parent);
            view.Construct(config);

            return view;
        }
    }
}