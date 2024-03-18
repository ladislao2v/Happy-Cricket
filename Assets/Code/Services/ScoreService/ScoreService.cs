using System;
using Code.Services.SaveLoadDataService;

namespace Code.Services.ScoreService
{
    public class ScoreService : IScoreService
    {
        private int _score;
        
        public int Record { get; private set; }
        
        public event Action<int> ScoreChanged;

        public void Add(int points)
        {
            if (points < 0)
                throw new ArgumentOutOfRangeException(nameof(points));

            _score += points;
            ScoreChanged?.Invoke(_score);

            if (_score > Record)
                Record = _score;
        }

        public void LoadData(ISaveLoadDataService saveLoadDataService)
        {
            Record = saveLoadDataService.LoadByCustomKey<int?>(nameof(Record)).GetValueOrDefault();
        }

        public void SaveData(ISaveLoadDataService saveLoadDataService)
        {
            saveLoadDataService.SaveByCustomKey((int?)Record, nameof(Record));
        }
    }
}