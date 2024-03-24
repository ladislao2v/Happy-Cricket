using System;
using Code.Services.SaveLoadDataService;
using Code.Services.WalletService;

namespace Code.Services.ScoreService
{
    public class ScoreService : IScoreService
    {
        private readonly IWalletService _walletService;
        
        private int _score;

        public int CurrentThrow { get; private set; } = 0;
        public int Score => _score;
        public int TargetScore { get; private set; }
        public int Record { get; private set; }
        public bool IsWin => _score >= TargetScore;

        public event Action<int, int> ScoreChanged;

        public ScoreService(IWalletService walletService)
        {
            _walletService = walletService;
        }

        public void Add(int points)
        {
            if (points < 0)
                throw new ArgumentOutOfRangeException(nameof(points));

            _score += points;
            _walletService.Add(points);
            
            ScoreChanged?.Invoke(points, _score);
            AddHit();
            
            if (_score > Record)
                Record = _score;
        }

        public void SetTarget(int target)
        {
            TargetScore = target;
        }

        private void AddHit()
        {
            CurrentThrow++;
        }

        public void Reset()
        {
            _score = 0;
            ScoreChanged?.Invoke(0, _score);
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