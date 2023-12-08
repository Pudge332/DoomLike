using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyRepository : Repository
{
    StorageRepository _storageRepository;
    private Storage _data;
    public int CurrencyValue { get; set; }
    public override void Initialize()
    {
        _storageRepository = Game.GetRepository<StorageRepository>();
        _data = _storageRepository.data;
        CurrencyValue = _data.CurrencyValue;

    }

    public override void Save()
    {
        _data.CurrencyValue = CurrencyValue;
        _storageRepository.Save();
    }
}
