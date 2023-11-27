using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchTester : MonoBehaviour
{
    //public static SceneManagerBase sceneManagerBase;
    //public static Scene scene;
    //private CurrencyRepository _currencyRepository;
    //private CurrencyInteractor _currencyInteractor;

    //public static InteractorsBase interactorsBase;
    //public static RepositoriesBase repositoriesBase;
    // Start is called before the first frame update
    void Start()
    {
        //_currencyRepository = new CurrencyRepository();
        //_currencyRepository.Initialize();
        //_currencyInteractor = new CurrencyInteractor();    
        //_currencyInteractor.Initialize();

        //Debug.Log($"Currency has on start {_currencyInteractor.CurrencyValue}");

        //StartCoroutine(StartGameCorutine());

        //var sceneConfig = new SceneConfigExample();
        //scene = new Scene(sceneConfig);

        //StartCoroutine(scene.InitializeCorutine());

        //sceneManagerBase = new SceneManagerExample();
        //sceneManagerBase.InitializeSceneDict();
        //sceneManagerBase.LoadCurrentScene();
        Game.Run();
    }

    //IEnumerator StartGameCorutine()
    //{
    //    interactorsBase = new InteractorsBase();
    //    repositoriesBase = new RepositoriesBase();

    //    interactorsBase.CreateAllInteractors();
    //    repositoriesBase.CreateAllRepositorys();

    //    yield return null;

    //    interactorsBase.SendOnCreateToAllInteractors();
    //    repositoriesBase.SendOnCreateToAllRepositorys();

    //    yield return null;

    //    interactorsBase.OnInitializetToAllInteractors();
    //    repositoriesBase.OnInitializetToAllRepositorys();

    //    yield return null;

    //    interactorsBase.SendOnStartToAllInteractors();
    //    repositoriesBase.SendOnStartToAllRepositorys();
    //    return null;
    //}
    // Update is called once per frame
    void Update()
    {
        if(!Currency.isInitialized)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            Currency.AddCurrency(this, 5);
            //`_currencyInteractor.AddCurrency(this, 5);
            Debug.Log($"Add : Currency has {Currency.CurrencyValue}");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Currency.Spend(this, 5);
            //_currencyInteractor.SpendCurrency(this, 5);
            Debug.Log($"Spend : Currency has {Currency.CurrencyValue}");
        }
    }
}
