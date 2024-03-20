using System;
using Code.Services.SaveLoadDataService;

namespace Code.Services.WalletService
{
    public interface IWalletService : ILoadable, ISavable
    {
        event Action<int> MoneyChanged;
        
        void Add(int value);
        bool TrySpend(int value);
    }
    
    public class WalletService : IWalletService
    {
        private int _money;
        
        public event Action<int> MoneyChanged;

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

        public void LoadData(ISaveLoadDataService saveLoadDataService)
        {
            throw new NotImplementedException();
        }

        public void SaveData(ISaveLoadDataService saveLoadDataService)
        {
            throw new NotImplementedException();
        }
    }
}