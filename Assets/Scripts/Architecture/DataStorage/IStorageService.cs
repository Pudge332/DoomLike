using System;

public interface IStorageService 
{
    public Storage Load();
    public void Save(Storage data, Action<bool> callback = null);
}
