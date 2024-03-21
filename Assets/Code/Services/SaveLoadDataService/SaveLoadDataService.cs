using Newtonsoft.Json;
using UnityEngine;

namespace Code.Services.SaveLoadDataService
{
    public class SaveLoadDataService : ISaveLoadDataService
    {
        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto
        };
        
        public void SaveByCustomKey<TSavable>(TSavable data, string key)
        {
            SaveData<TSavable>(key, data);
        }
        
        public void Save<TSavable>(TSavable data)
        {
            SaveData(typeof(TSavable).ToString(), data);
        }

        public TLoadable Load<TLoadable>()
        {
            return LoadData<TLoadable>(typeof(TLoadable).ToString());
        }

        public TLoadable LoadByCustomKey<TLoadable>(string key)
        {
            return LoadData<TLoadable>(key);
        }

        private void SaveData<TSavable>(string key, TSavable data)
        {
            string json = JsonConvert.SerializeObject(data, _settings);
            
            PlayerPrefs.SetString(key, json);
            PlayerPrefs.Save();
            
            Debug.Log("Save is done!");
        }

        private TLoadable LoadData<TLoadable>(string key)
        {
            string json = PlayerPrefs.GetString(key);

            TLoadable loadable = JsonConvert.DeserializeObject<TLoadable>(json, _settings);

            if (loadable != null)
                Debug.Log("Load is done");
            
            return loadable;
        }
    }
}