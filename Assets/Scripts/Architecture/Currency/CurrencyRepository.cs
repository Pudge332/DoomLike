using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyRepository : Repository
{
    //private IStorageService _storageService; //Работает, но хранит отдельную версию состояния и может затереть данные(переделать Storage в синглтон???)
    StorageRepository _storageRepository;
    private Storage _data;
    public int CurrencyValue { get; set; }
    public override void Initialize()
    {
        _storageRepository = Game.GetRepository<StorageRepository>();
        //_storageService = new BinaryStorageService();
        _data = _storageRepository.data;
        CurrencyValue = _data.CurrencyValue;

    }

    public override void Save()
    {
        _data.CurrencyValue = CurrencyValue;
        _storageRepository.Save();
    }
}
