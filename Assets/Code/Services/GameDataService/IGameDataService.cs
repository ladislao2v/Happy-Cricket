using Code.Services.SaveLoadDataService;

namespace Code.Services.GameDataService
{
    public interface IGameDataService
    {
        void LoadData();
        void SaveData();
        void Add(ILoadable loadable);
    }
}