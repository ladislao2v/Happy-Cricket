using Code.Services.SaveLoadDataService;
using Code.Views.Players;
using UnityEngine;

namespace Code.Services.SkinService
{
    public class SkinService : ISkinService
    {
        private readonly StrikerView _strikerView;

        private GameObject _lastSkin;

        public SkinService(StrikerView strikerView) => 
            _strikerView = strikerView;

        public void Dress(GameObject skin) => 
            _strikerView.SetSkin(skin);

        public void LoadData(ISaveLoadDataService saveLoadDataService) =>
            Dress(saveLoadDataService
                .LoadByCustomKey<GameObject>(nameof(_lastSkin)));

        public void SaveData(ISaveLoadDataService saveLoadDataService) => 
            saveLoadDataService.SaveByCustomKey(_lastSkin, nameof(_lastSkin));
    }
}