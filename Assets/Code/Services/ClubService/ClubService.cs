using Code.Services.SaveLoadDataService;

namespace Code.Services.ClubService
{
    public class ClubService : IClubService
    {
        public IClubData ClubData { get; private set; }

        public void CreateClub(IClubData clubData)
        {
            ClubData = clubData;
        }

        public void LoadData(ISaveLoadDataService saveLoadDataService)
        {
            var clubData = 
                saveLoadDataService.LoadByCustomKey<IClubData>(nameof(ClubData));
        }

        public void SaveData(ISaveLoadDataService saveLoadDataService)
        {
            saveLoadDataService.SaveByCustomKey(ClubData, nameof(ClubData));
        }
    }
}