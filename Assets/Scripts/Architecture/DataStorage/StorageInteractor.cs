

public class StorageInteractor : Interactor
{
    private StorageRepository _storageRepository;
    public StorageInteractor()
    {

    }

    public override void OnCreate()
    {
        base.OnCreate();
        _storageRepository = Game.GetRepository<StorageRepository>();
    }

    public override void Initialize()
    {
        base.Initialize();
    }
}
