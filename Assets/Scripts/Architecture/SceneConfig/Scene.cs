

using System.Collections;
using UnityEngine;

public class Scene
{
    private InteractorsBase _interactorsBase;
    private RepositoriesBase _repositoriesBase;
    private SceneConfig _sceneConfig;

    public Scene(SceneConfig sceneConfig)
    {
        _sceneConfig = sceneConfig;
        _interactorsBase = new InteractorsBase(_sceneConfig);
        _repositoriesBase = new RepositoriesBase(_sceneConfig);
    }

    public Coroutine InitializeAsync()
    {
        return Corutines.StartIncomingCorutine(InitializeCorutine());
    }
    public IEnumerator InitializeCorutine()
    {
        _interactorsBase.CreateAllInteractors();
        _repositoriesBase.CreateAllRepositorys();

        yield return null;

        _interactorsBase.SendOnCreateToAllInteractors();
        _repositoriesBase.SendOnCreateToAllRepositorys();

        yield return null;

        _interactorsBase.OnInitializetToAllInteractors();
        _repositoriesBase.OnInitializetToAllRepositorys();

        yield return null;

        _interactorsBase.SendOnStartToAllInteractors();
        _repositoriesBase.SendOnStartToAllRepositorys();
    }

    public T GetRepository<T>() where T : Repository
    {
        return _repositoriesBase.GetRepository<T>();
    }

    public T GetInteractor<T>() where T : Interactor
    {
        return _interactorsBase.GetInteractor<T>();
    }
}
