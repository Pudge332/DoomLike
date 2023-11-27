using System;
using System.Collections;
using System.Collections.Generic;


public class RepositoriesBase
{
    private Dictionary<Type, Repository> _repositoriesDict;
    private SceneConfig _sceneConfig;
    public RepositoriesBase(SceneConfig sceneConfig)
    {
        //_repositoriesDict = new Dictionary<Type, Repository>(); // !Лучше сразу указать размерность словаря для экономии памяти!
        _sceneConfig = sceneConfig;
    }

    public void CreateAllRepositorys()
    {
        //OnCreateRepository<CurrencyRepository>();
        _repositoriesDict = _sceneConfig.CreateAllRepositories();
    }

    //private void OnCreateRepository<T>() where T : Repository, new()
    //{
    //    var Repository = new T();
    //    var TypeRepository = typeof(T);
    //    _repositoriesDict.Add(TypeRepository, Repository);
    //}

    public void SendOnCreateToAllRepositorys()
    {
        var allRepositorys = _repositoriesDict.Values;
        foreach (var Repository in allRepositorys)
        {
            Repository.OnCreate();
        }
    }

    public void SendOnStartToAllRepositorys()
    {
        var allRepositorys = _repositoriesDict.Values;
        foreach (var Repository in allRepositorys)
        {
            Repository.OnStart();
        }
    }

    public void OnInitializetToAllRepositorys()
    {
        var allRepositorys = _repositoriesDict.Values;
        foreach (var Repository in allRepositorys)
        {
            Repository.Initialize();
        }
    }

    public T GetRepository<T>() where T : Repository
    {
        var Repository = _repositoriesDict[typeof(T)];
        return (T)Repository; //Если нет в словаре будет исключение через as исключения не будет
    }
}
