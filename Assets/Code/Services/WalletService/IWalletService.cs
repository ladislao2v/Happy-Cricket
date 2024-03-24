using System;
using Code.Services.SaveLoadDataService;

namespace Code.Services.WalletService
{
    public interface IWalletService : ILoadable, ISavable
    {
        event Action<int> MoneyChanged;
        int Value { get; }

        void Add(int value);
        bool TrySpend(int value);
    }
}