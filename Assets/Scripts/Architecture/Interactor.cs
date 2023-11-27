
using Unity.VisualScripting;

public abstract class Interactor 
{
    public virtual void OnCreate() { } //После создания респозиториев и интеракторов

    public virtual void Initialize() { } //После OnCreate
    public virtual void OnStart() { } //После инициализации
}
