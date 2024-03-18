using System;
using Code.Services.SaveLoadDataService;
using UnityEngine;

namespace Code.Services.AudioService
{
    public class AudioService : IAudioService
    {
        private readonly AudioSource _audioSource;
        private readonly int _min = 0;
        private readonly int _max = 1;

        public AudioService(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }

        public bool IsMute { get; private set; }

        public void Enable()
        {
            _audioSource.volume = _max;
            IsMute = false;
        }

        public void Disable()
        {
            _audioSource.volume = _min;
            IsMute = true;
        }

        public void SaveData(ISaveLoadDataService saveLoadDataService)
        {
            saveLoadDataService.SaveByCustomKey((bool?)IsMute, nameof(IsMute));
        }

        public void LoadData(ISaveLoadDataService saveLoadDataService)
        {
            IsMute = saveLoadDataService.LoadByCustomKey<bool?>(nameof(IsMute)).GetValueOrDefault();
            
            if(IsMute)
                Disable();
        }
    }
}