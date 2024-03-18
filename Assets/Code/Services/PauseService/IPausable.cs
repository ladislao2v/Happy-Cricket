using Unity.VisualScripting;

namespace Code.Services.PauseService
{
    public interface IPausable
    {

        void OnPause();
        void OnResume();
    }
}