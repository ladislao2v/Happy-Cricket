using Code.Services.AchievementsService;
using Code.UI.Achievements;
using UnityEngine;
using Zenject;

namespace Code.Services.Factories.AchievementViewFactory
{
    public class AchievementViewFactory : IAchievementViewFactory
    {
        private readonly DiContainer _diContainer;
        private readonly AchievementView _prefab;

        public AchievementViewFactory(DiContainer diContainer,AchievementView prefab)
        {
            _diContainer = diContainer;
            _prefab = prefab;
        }
        
        public IAchievementView Create(IAchievementConfig config, Transform parent)
        {
            var view = _diContainer.InstantiatePrefabForComponent<AchievementView>(_prefab, parent);
            view.Construct(config);

            return view;
        }
    }
}