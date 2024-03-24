using System;
using Code.Services.SaveLoadDataService;

namespace Code.Services.WalletService
{
    public class WalletService : IWalletService
    {
        private int _money;
        
        public event Action<int> MoneyChanged;
        public int Value => _money;

        public void Add(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _money += value;
            
            MoneyChanged?.Invoke(_money);
        }

        public bool TrySpend(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            if (value > _money)
                return false;

            _money -= value;
            
            MoneyChanged?.Invoke(_money);

            return true;
        }

        public void LoadData(ISaveLoadDataService saveLoadDataService) =>
            _money = saveLoadDataService
                .LoadByCustomKey<int?>(nameof(_money))
                .GetValueOrDefault();

        public void SaveData(ISaveLoadDataService saveLoadDataService) => 
            saveLoadDataService.SaveByCustomKey((int?)_money, nameof(_money));
    }
}