using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class BinaryStorageService : IStorageService
{
    private readonly string _filePath;

    public BinaryStorageService()
    {
        _filePath = Application.persistentDataPath + "/GameSave.dat";
    }

    public Storage Load()
    {
        using(FileStream file = File.Open(_filePath, FileMode.OpenOrCreate))
        {
            if(file.Length == 0)
            {
                Debug.Log("First Save");
                file.Close();
                Save(new Storage());
                return new Storage();
            }
            file.Position = 0;
            object loadedData = new BinaryFormatter().Deserialize(file);
            if(loadedData is Storage storage)
            {
                return storage;
            }
            else
            {
                throw new Exception("File was not saved correctly");
            }
        }
    }

    public void Save(Storage data, Action<bool> callback = null)
    {
        using(FileStream file = File.Create(_filePath))
        {
            new BinaryFormatter().Serialize(file, data);
        }
    }
}
