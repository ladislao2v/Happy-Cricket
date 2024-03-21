using Code.Services.SaveLoadDataService;

namespace Code.Services.ClubService
{
    public interface IClubService: ILoadable, ISavable
    {
        IClubData ClubData { get; }
        void CreateClub(IClubData clubData);
    }
}