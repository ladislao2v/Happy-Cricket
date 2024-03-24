using Code.Services.SaveLoadDataService;
using UnityEditor;

namespace Code.Services.DailyRewardService
{
    public interface IDailyRewardService:  ILoadable, ISavable
    {
        int CurrentDay { get; }
        bool CanGiveBonus { get; }
        void SyncTime();
        void Take();
    }
}