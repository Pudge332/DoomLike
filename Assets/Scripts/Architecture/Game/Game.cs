using System;
using System.Collections;

public static class Game 
{
    public static event Action OnGameInitializeEvent;
    public static SceneManagerBase sceneManager { get; private set; }

    public static void Run()
    {
        sceneManager = new SceneManagerExample();
        Corutines.StartIncomingCorutine(InitializeGameRoutine());
    }

    private static IEnumerator InitializeGameRoutine()
    {
        sceneManager.InitializeSceneDict();
        yield return sceneManager.LoadCurrentScene();
        OnGameInitializeEvent?.Invoke();
    }

    public static T GetInteractor<T>() where T : Interactor
    {
        return sceneManager.GetInteractor<T>();
    }

    public static T GetRepository<T>() where T : Repository
    {
        return sceneManager.GetRepository<T>();
    }
}
