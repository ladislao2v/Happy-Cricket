using Code.Services.Factories.MonoBehaviourFactory;
using Code.Services.Pool;
using Code.Views.Ball;
using UnityEngine;
using Zenject;

namespace Code.Installers.Local
{
    public class PoolInstaller : MonoInstaller
    {
        [SerializeField] private BallView _prefab;
        [SerializeField] private Transform _container;

        public override void InstallBindings()
        {
            var factory = new SimpleFactory<BallView>(Container, _prefab);

            Container
                .BindInterfacesAndSelfTo<QueuePool<BallView>>()
                .AsSingle()
                .WithArguments(factory, _container);
        }
    }
}