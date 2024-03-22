using System;
using Code.Services.Factories.PoolFactory;
using Code.Services.Pool;
using Code.Views.Ball;
using UnityEngine;
using Zenject;

namespace Code.Installers.Local
{
    public class PoolInstaller : MonoInstaller
    {
        [SerializeField] private BallView[] _prefabs;
        [SerializeField] private Transform _container;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PoolFactory<BallView>>()
                .AsSingle()
                .WithArguments(_prefabs);

            Container
                .BindInterfacesAndSelfTo<QueuePool<BallView>>()
                .AsSingle()
                .WithArguments(_container);
        }
    }

    [Serializable]
    public class FactoryData
    {
        [field: SerializeField] public Transform Container { get; private set; }
        [field: SerializeField] public BallView[] BallViews { get; private set; }
    }
}