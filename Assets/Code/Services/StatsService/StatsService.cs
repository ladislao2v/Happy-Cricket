using Code.Services.SaveLoadDataService;

namespace Code.Services.StatsService
{
    public class StatsService : IStatsService
    {
        public int ChallengeWins { get; private set; }
        public int MatchWins { get; private set;}
        public int HitCount { get; private set;}
        public int MissedCount { get; private set;}
        
        public void AddChallengeWin() => 
            ChallengeWins++;

        public void AddMatchWin() => 
            MatchWins++;

        public void AddHitCount() => 
            HitCount++;

        public void AddMissedCount() => 
            MissedCount++;

        public void LoadData(ISaveLoadDataService saveLoadDataService)
        {
            ChallengeWins = saveLoadDataService
                .LoadByCustomKey<int?>(nameof(ChallengeWins))
                .GetValueOrDefault();
            MatchWins = saveLoadDataService
                .LoadByCustomKey<int?>(nameof(MatchWins))
                .GetValueOrDefault();
            HitCount = saveLoadDataService
                .LoadByCustomKey<int?>(nameof(HitCount))
                .GetValueOrDefault();
            MissedCount = saveLoadDataService
                .LoadByCustomKey<int?>(nameof(MissedCount))
                .GetValueOrDefault();
        }

        public void SaveData(ISaveLoadDataService saveLoadDataService)
        {
            saveLoadDataService.SaveByCustomKey((int?)ChallengeWins, nameof(ChallengeWins));
            saveLoadDataService.SaveByCustomKey((int?)MatchWins , nameof(MatchWins ));
            saveLoadDataService.SaveByCustomKey((int?)HitCount, nameof(HitCount));
            saveLoadDataService.SaveByCustomKey((int?)MissedCount, nameof(MissedCount));
        }
    }
}