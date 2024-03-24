using Code.Services.SaveLoadDataService;
using Code.Services.StaticDataService;
using Code.Services.StaticDataService.Configs;
using Code.StateMachine;
using Code.Views.Players;
using UnityEngine;

namespace Code.Services.SkinService
{
    public class SkinService : ISkinService
    {
        private readonly StrikerView _strikerView;
        private readonly IItemConfig[] _skins;

        public int LastSkin { get; private set; }

        public SkinService(StrikerView strikerView, IStaticDataService staticDataService)
        {
            _strikerView = strikerView;
            _skins = staticDataService.GetShopItems();
        }

        public void Dress()
        {
            _strikerView.SetSkin(_skins[LastSkin].Prefab);
        }

        public void Dress(GameObject skin)
        {
            _strikerView.SetSkin(skin);
        }

        public void LoadData(ISaveLoadDataService saveLoadDataService)
        {
            LastSkin = saveLoadDataService
                .LoadByCustomKey<int?>(nameof(LastSkin))
                .GetValueOrDefault();

            Dress();
        }
        

        public void SaveData(ISaveLoadDataService saveLoadDataService) => 
            saveLoadDataService.SaveByCustomKey((int?)LastSkin, nameof(LastSkin));
    }
}