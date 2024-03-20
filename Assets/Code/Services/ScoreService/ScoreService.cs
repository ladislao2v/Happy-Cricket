using System;
using Code.Services.SaveLoadDataService;
using Code.Services.WalletService;
using UnityEngine.SocialPlatforms.Impl;

namespace Code.Services.ScoreService
{
    public class ScoreService : IScoreService
    {
        private readonly IWalletService _walletService;
        
        private int _score;
        
        public int Record { get; private set; }
        
        public event Action<int> ScoreChanged;

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
            
            ScoreChanged?.Invoke(_score);

            if (_score > Record)
                Record = _score;
        }

        public void Reset()
        {
            _score = 0;
            ScoreChanged?.Invoke(0);
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