namespace Code.Services.SaveLoadDataService
{
    public interface ILoadable
    {
        void LoadData(ISaveLoadDataService saveLoadDataService);
    }
}