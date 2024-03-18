using System;
using System.Collections.Generic;
using Code.Services.SaveLoadDataService;
using ModestTree;

namespace Code.Services.GameDataService
{
    class GameDataService : IGameDataService
    {
        private readonly ISaveLoadDataService _saveLoadDataService;
        private readonly List<ISavable> _savables = new();
        private readonly List<ILoadable> _loadables = new();

        public GameDataService(ISaveLoadDataService saveLoadDataService)
        {
            _saveLoadDataService = saveLoadDataService;
        }

        public void LoadData()
        {
            foreach (var loadable in _loadables)
            {
                loadable.LoadData(_saveLoadDataService);
            }
        }

        public void SaveData()
        {
            foreach (var savable in _savables)
            {
                savable.SaveData(_saveLoadDataService);
            }
        }

        public void Add(ILoadable loadable)
        {
            if (_loadables.Contains(loadable))
                return;
            
            if(loadable is ISavable savable)
                _savables.Add(savable);
            
            _loadables.Add(loadable);
        }
    }
}