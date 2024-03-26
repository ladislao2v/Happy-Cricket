using Code.Services.SaveLoadDataService;
using UnityEngine;

namespace Code.Services.SkinService
{
    public interface ISkinService : ILoadable, ISavable
    {
        int LastSkin { get; }
        void Dress(int index);
        void Dress();
    }
}