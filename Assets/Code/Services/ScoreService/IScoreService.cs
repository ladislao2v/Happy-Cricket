using System;
using Code.Services.SaveLoadDataService;

namespace Code.Services.ScoreService
{
    public interface IScoreService : ILoadable, ISavable
    {
        public int Record { get;}
        
        event Action<int> ScoreChanged;

        void Add(int points);
    }
}