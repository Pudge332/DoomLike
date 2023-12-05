
public abstract class Repository
{
    public abstract void Initialize(); //После OnCreate
    public abstract void Save();

    public virtual void OnCreate() { } //После создания респозиториев и интеракторов

    public virtual void OnStart() { } //После инициализации
}
