namespace Code.Services.SaveLoadDataService
{
    public interface ISaveLoadDataService
    {
        void SaveByCustomKey<TSavable>(TSavable data, string key);
        void Save<TSavable>(TSavable data);
        TLoadable Load<TLoadable>();
        TLoadable LoadByCustomKey<TLoadable>(string key);
    }
}