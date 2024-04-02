using System;
using System.Collections;
using Code.Services.CoroutineRunner;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Services.SceneLoaderService
{
    public class SceneLoader : ISceneLoaderService
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        public void Load(string name, Action loaded = null)
        {
            SceneManager.LoadScene(name);
        }

        public void Restart(Action loaded = null)
        {
            var activeScene = SceneManager.GetActiveScene();

            SceneManager.LoadScene(activeScene.name);
        }

        private IEnumerator LoadScene(string name, Action loaded)
        {
            AsyncOperation waitSceneLoading = SceneManager.LoadSceneAsync(name);

            while (!waitSceneLoading.isDone)
                yield return null;
            
            loaded?.Invoke();
        }
    }
}