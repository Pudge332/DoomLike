using System;
using System.Collections;
using System.Collections.Generic;

public class InteractorsBase 
{
    private Dictionary<Type, Interactor> _interactorsDict;
    private SceneConfig _sceneConfig;
    public InteractorsBase(SceneConfig sceneConfig)
    {
        //_interactorsDict = new Dictionary<Type, Interactor>(); // !Лучше сразу указать размерность словаря для экономии памяти!
        _sceneConfig = sceneConfig;
    }

    public void CreateAllInteractors()
    {
        _interactorsDict = _sceneConfig.CreateAllInteractors();
    }

    public void SendOnCreateToAllInteractors()
    {
        var allInteractors = _interactorsDict.Values;
        foreach(var interactor in allInteractors )
        {
            interactor.OnCreate();
        }
    }

    public void SendOnStartToAllInteractors()
    {
        var allInteractors = _interactorsDict.Values;
        foreach (var interactor in allInteractors)
        {
            interactor.OnStart();
        }
    }

    public void OnInitializetToAllInteractors()
    {
        var allInteractors = _interactorsDict.Values;
        foreach (var interactor in allInteractors)
        {
            interactor.Initialize();
        }
    }

    public T GetInteractor<T>() where T : Interactor
    {
        var interactor = _interactorsDict[typeof(T)];
        return (T)interactor; //Если нет в словаре будет исключение через as исключения не будет
    }
}
