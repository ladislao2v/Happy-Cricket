using System;
using System.Collections;
using Code.Services.CoroutineRunner;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Code.Services.SceneLoaderService
{
    public class SceneLoaderService : ISceneLoaderService
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly ZenjectSceneLoader _zenjectSceneLoader;

        public SceneLoaderService(ICoroutineRunner coroutineRunner, ZenjectSceneLoader zenjectSceneLoader)
        {
            _coroutineRunner = coroutineRunner;
            _zenjectSceneLoader = zenjectSceneLoader;
        }
        
        public void Load(string name, Action loaded = null)
        {
            SceneManager.LoadScene(name);
        }

        public void Restart(Action loaded = null)
        {
            var activeScene = SceneManager.GetActiveScene();

            _zenjectSceneLoader.LoadScene(activeScene.name);
        }
    }
}