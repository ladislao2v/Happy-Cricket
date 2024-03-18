using Code.Services.SaveLoadDataService;

namespace Code.Services.AudioService
{
    public interface IAudioService : ISavable, ILoadable
    {
        bool IsMute { get; }
        void Enable();
        void Disable();
    }
}