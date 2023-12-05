
using System;
using System.Diagnostics;

public class StorageRepository : Repository
{
    private IStorageService storageService;
    public Storage data { get; private set; }

    public override void OnCreate()
    {
        base.OnCreate();
        storageService = new BinaryStorageService();
        Load();
    }
    public override void Initialize()
    {
        Console.WriteLine("Init game Data");
    }

    public override void Save()
    {
        storageService.Save(data);
    }

    public void Load()
    {
        data = storageService.Load();
    }
}
