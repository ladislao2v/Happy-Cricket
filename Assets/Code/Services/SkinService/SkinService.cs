using Code.Services.SaveLoadDataService;
using Code.Views.Players;
using UnityEngine;

namespace Code.Services.SkinService
{
    public class SkinService : ISkinService
    {
        private readonly StrikerView _strikerView;

        private bool _isFirst;
        
        public int LastSkin { get; private set; } = -1;
        

        public SkinService(StrikerView strikerView)
        {
            _strikerView = strikerView;
        }

        public void Dress()
        {
            if(LastSkin < 0)
                return;
            
            if(_isFirst == false)
                return;

            _strikerView.SetSkin(LastSkin);
        }

        public void Dress(int index)
        {
            if(_isFirst == false)
                _isFirst = true;

            _strikerView.SetSkin(LastSkin);
            LastSkin = index;
        }

        public void LoadData(ISaveLoadDataService saveLoadDataService)
        {
            LastSkin = saveLoadDataService
                .LoadByCustomKey<int?>(nameof(LastSkin))
                .GetValueOrDefault();
            
            _isFirst = saveLoadDataService
                .LoadByCustomKey<bool?>(nameof(_isFirst))
                .GetValueOrDefault();
        }
        

        public void SaveData(ISaveLoadDataService saveLoadDataService)
        {
            saveLoadDataService.SaveByCustomKey((int?) LastSkin, nameof(LastSkin));
            saveLoadDataService.SaveByCustomKey((bool?) _isFirst, nameof(_isFirst));
        }
    }
}