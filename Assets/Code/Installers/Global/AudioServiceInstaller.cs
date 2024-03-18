using Code.Services.AudioService;
using UnityEngine;
using Zenject;

namespace Code.Installers.Local
{
    public class AudioServiceInstaller : MonoInstaller
    {
        [SerializeField] private AudioSource _audioSource;
        public override void InstallBindings()
        {
            Container
                .Bind<AudioSource>()
                .FromInstance(_audioSource)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<AudioService>()
                .AsSingle();
        }
    }
}