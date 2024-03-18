using System;

namespace Code.Services.SceneLoaderService
{
    public interface ISceneLoaderService
    {
        void Load(string name, Action loaded = null);
        void Restart(Action loaded = null);
    }
}