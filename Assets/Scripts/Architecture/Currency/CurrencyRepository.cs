using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyRepository : Repository
{
    private const string _KEY = "BANK_KEY"; //Переделать на сериализацию данных

    public int CurrencyValue { get; set; }
    public override void Initialize()
    {
        CurrencyValue = PlayerPrefs.GetInt(_KEY, 0);
    }

    public override void Save()
    {
        PlayerPrefs.SetInt(_KEY, this.CurrencyValue);
    }
}
