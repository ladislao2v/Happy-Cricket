using Code.Services.StaticDataService.Configs;

namespace Code.Services.StaticDataService
{
    public interface IStaticDataService
    {
        ChampionshipData GetChampionship(int level);
    }
}