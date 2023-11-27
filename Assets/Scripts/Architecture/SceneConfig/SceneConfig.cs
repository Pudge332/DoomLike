
using System;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;

public abstract class SceneConfig
{
    public abstract Dictionary<Type, Repository> CreateAllRepositories();
    public abstract Dictionary<Type, Interactor> CreateAllInteractors();

    public abstract string sceneName { get; }
    public void CreateInteractor<T>(Dictionary<Type, Interactor> interactorsDict) where T : Interactor, new()
    {
        var interactor = new T();
        var type = typeof(T);

        interactorsDict[type] = interactor;
    }

    public void CreateRepository<T>(Dictionary<Type, Repository> repositoriesDict) where T : Repository, new()
    {
        var repository = new T();
        var type = typeof(T);

        repositoriesDict[type] = repository;
    }
}
