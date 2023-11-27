

using System;
using System.Collections.Generic;

public class SceneConfigExample : SceneConfig
{
    public const string SCENE_NAME = "SampleScene";
    public override string sceneName => SCENE_NAME;

    public override Dictionary<Type, Interactor> CreateAllInteractors()
    {
        var interactorsDict = new Dictionary<Type, Interactor>();

        CreateInteractor<CurrencyInteractor>(interactorsDict);

        return interactorsDict;
    }

    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoryDict = new Dictionary<Type, Repository>();

        CreateRepository<CurrencyRepository>(repositoryDict);

        return repositoryDict;
    }
}
