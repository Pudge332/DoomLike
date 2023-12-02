using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyRepository : Repository
{
    private IStorageService _storageService; //Работает, но хранит отдельную версию состояния и может затереть данные(переделать Storage в синглтон???)
    private Storage _data;
    public int CurrencyValue { get; set; }
    public override void Initialize()
    {
        _storageService = new BinaryStorageService();
        _data = _storageService.Load();
        CurrencyValue = _data.CurrencyValue;
    }

    public override void Save()
    {
        _data.CurrencyValue = CurrencyValue;
        _storageService.Save(_data);
    }
}
