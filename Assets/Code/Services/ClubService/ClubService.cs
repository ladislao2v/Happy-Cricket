using Code.Services.SaveLoadDataService;

namespace Code.Services.ClubService
{
    public class ClubService : IClubService
    {
        public ClubData ClubData { get; private set; }
        public bool IsCreated { get; private set; }

        public void CreateClub(ClubData clubData)
        {
            ClubData = clubData;
            IsCreated = true;
        }

        public void LoadData(ISaveLoadDataService saveLoadDataService)
        {
            ClubData = 
                saveLoadDataService.LoadByCustomKey<ClubData>(nameof(ClubData));
            
            IsCreated = 
                saveLoadDataService
                    .LoadByCustomKey<bool?>(nameof(IsCreated))
                    .GetValueOrDefault();
        }

        public void SaveData(ISaveLoadDataService saveLoadDataService)
        {
            saveLoadDataService.SaveByCustomKey(ClubData, nameof(ClubData));
            saveLoadDataService.SaveByCustomKey((bool?)IsCreated, nameof(IsCreated));
        }
    }
}