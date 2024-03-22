using Code.Services.Factories.PoolFactory;
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
            var factory = new PoolFactory<BallView>(Container, _prefab, TODO);

            Container
                .BindInterfacesAndSelfTo<QueuePool<BallView>>()
                .AsSingle()
                .WithArguments(factory, _container);
        }
    }
}