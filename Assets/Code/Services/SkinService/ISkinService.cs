using Code.Services.SaveLoadDataService;
using UnityEngine;

namespace Code.Services.SkinService
{
    public interface ISkinService : ILoadable, ISavable
    {
        void Dress(GameObject skin);
    }
}