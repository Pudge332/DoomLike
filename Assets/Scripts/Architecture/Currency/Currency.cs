

using System;
using UnityEngine.PlayerLoop;

public static class Currency //патерн Фасад(видео в плейлисте устаревшее)
{
    public static event Action OnCurrencyInitializedEvent; //Событие инициализации 
    //public static int CurrencyValue => _currencyInteractor.CurrencyValue;
    public static int CurrencyValue
    {
        get
        {
            ChechClass();
            return _currencyInteractor.CurrencyValue;
        }
    }
    public static bool isInitialized { get; private set; }
    private static CurrencyInteractor _currencyInteractor;
    public static void Initializatize(CurrencyInteractor interactor)
    {
        _currencyInteractor = interactor;
        isInitialized = true;
        OnCurrencyInitializedEvent?.Invoke(); //? проверка на null
    }

    public static bool isEnoughCurrency(int value)
    {
        ChechClass();
        return _currencyInteractor.IsEnoughtCurrency(value);
    }

    public static void AddCurrency(object sender, int value)
    {
        ChechClass();
        _currencyInteractor.AddCurrency(sender, value);
    }

    public static void Spend(object sender, int value)
    {
        ChechClass();
        _currencyInteractor.SpendCurrency(sender, value);
    }

    private static void ChechClass() //Проверка инициализации
    {
        if(!isInitialized)
        {
            throw new Exception("Currency is not initialize now");
        }
    }
}
