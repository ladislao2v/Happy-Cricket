using System;
using Code.Services.SaveLoadDataService;

namespace Code.Services.DailyRewardService
{
    public class DailyRewardService : IDailyRewardService
    {
        private int _lastDay;
        private DateTime _lastDate;
        
        public int CurrentDay { get; private set; }

        public bool CanGiveBonus => _lastDay < CurrentDay;

        public void SyncTime()
        {
            if(_lastDay == CurrentDay)
                return;

            CurrentDay = _lastDay;
            
            if (_lastDay == 0)
            {
                CurrentDay = 1;
                return;
            }

            var time = DateTime.Now;

            if (time.Day == _lastDate.Day)
            {
                return;
            }

            CurrentDay += 1;
            _lastDate = time;
        }

        public void Take()
        {
            CurrentDay = _lastDay;
        }

        public void LoadData(ISaveLoadDataService saveLoadDataService)
        {
            _lastDay = saveLoadDataService
                .LoadByCustomKey<int?>(nameof(CurrentDay))
                .GetValueOrDefault();

            _lastDate = saveLoadDataService
                .LoadByCustomKey<DateTime?>(nameof(_lastDate))
                .GetValueOrDefault();
        }

        public void SaveData(ISaveLoadDataService saveLoadDataService)
        {
            saveLoadDataService
                .SaveByCustomKey((int?) CurrentDay, nameof(CurrentDay));

            saveLoadDataService
                .SaveByCustomKey((DateTime?)_lastDate, nameof(DateTime));
        }
    }
}