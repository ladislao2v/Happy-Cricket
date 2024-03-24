using System;
using Code.Services.SaveLoadDataService;

namespace Code.Services.ScoreService
{
    public interface IScoreService : ILoadable, ISavable
    {
        public int CurrentThrow { get; }
        public int TargetScore { get; }
        public int Score { get; }
        public int Record { get;}
        
        bool IsWin { get; }
        
        event Action<int, int> ScoreChanged;

        void Add(int points);
        void SetTarget(int target);
        void Reset();
    }
}