using Code.Services.SaveLoadDataService;

namespace Code.Services.ClubService
{
    public interface IClubService: ILoadable, ISavable
    {
        ClubData ClubData { get; }
        bool IsCreated { get; }
        void CreateClub(ClubData clubData);
    }
}