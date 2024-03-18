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
            _coroutineRunner.StartCoroutine(LoadScene(name, loaded));
        }

        public void Restart(Action loaded = null)
        {
            var activeScene = SceneManager.GetActiveScene();

            _coroutineRunner.StartCoroutine(LoadScene(activeScene.name, loaded));
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