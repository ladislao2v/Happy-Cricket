using Code.Services.SaveLoadDataService;

namespace Code.Services.StatsService
{
    public interface IStatsService : ILoadable, ISavable
    {
        public int ChallengeWins { get; }
        public int MatchWins { get; }
        public int HitCount { get; }
        public int MissedCount { get; }

        void AddChallengeWin();
        void AddMatchWin();
        void AddHitCount();
        void AddMissedCount();
    }
}