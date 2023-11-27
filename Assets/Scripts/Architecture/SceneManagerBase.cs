using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
public abstract class SceneManagerBase
{
    public event Action<Scene> OnSceneLoadedEvent;
    public Scene scene { get; private set; }
    public bool isLoading { get; private set; }

    protected Dictionary<string, SceneConfig> sceneConfigDict;

    public SceneManagerBase()
    {
        sceneConfigDict = new Dictionary<string, SceneConfig>();
    }

    public abstract void InitializeSceneDict();

    public Coroutine LoadCurrentScene()
    {
        if (isLoading)
        {
            throw new Exception("Scene is loading now");
        }
        string sceneName = SceneManager.GetActiveScene().name;
        SceneConfig config = sceneConfigDict[sceneName];
        return Corutines.StartIncomingCorutine(LoadCurrentSceneAsync(config));
    }
    private IEnumerator LoadCurrentSceneAsync(SceneConfig sceneConfig) //Загрузка при старте
    {
        isLoading = true;
        yield return Corutines.StartIncomingCorutine(InitializeSceneAsync(sceneConfig));
        isLoading = false;
        OnSceneLoadedEvent?.Invoke(scene);
    }

    public Coroutine LoadNewScene(string sceneName)
    {
        if(isLoading)
        {
            throw new Exception("Scene is loading now");
        }
        
        SceneConfig config = sceneConfigDict[sceneName];
        return Corutines.StartIncomingCorutine(LoadNewSceneAsync(config));
    }
    private IEnumerator LoadNewSceneAsync(SceneConfig sceneConfig) //Загрузка новой сцены
    {
        isLoading = true;
        yield return Corutines.StartIncomingCorutine(LoadSceneAsync(sceneConfig));
        yield return Corutines.StartIncomingCorutine(InitializeSceneAsync(sceneConfig));
        isLoading = false;
        OnSceneLoadedEvent.Invoke(scene);
    }

    private IEnumerator LoadSceneAsync(SceneConfig sceneConfig) //загрузка сцены 
    {
        UnityEngine.AsyncOperation async = SceneManager.LoadSceneAsync(sceneConfig.sceneName);
        async.allowSceneActivation = false;

        while(async.progress < 0.9f) //на 90% загрузка сцены будет полностью заверешена, дальше выгрузка текущей
        {
            yield return null;
        }
        async.allowSceneActivation = true;
    }

    private IEnumerator InitializeSceneAsync(SceneConfig sceneConfig) //Инициализация репозиториев и интеракторов
    {
        scene = new Scene(sceneConfig);
        yield return scene.InitializeAsync();
    }

    public T GetRepository<T>() where T : Repository
    {
        return scene.GetRepository<T>();
    }

    public T GetInteractor<T>() where T : Interactor
    {
        return scene.GetInteractor<T>();
    }
}
