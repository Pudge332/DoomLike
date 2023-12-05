
public class CurrencyInteractor : Interactor 
{
    private CurrencyRepository _repository;

    //Необходимость под вопросом
    public int CurrencyValue => _repository.CurrencyValue;
    public CurrencyInteractor()
    {
        
    }

    public override void OnCreate()
    {
        base.OnCreate();
        _repository = Game.GetRepository<CurrencyRepository>();
    }

    public override void Initialize()
    {
        Currency.Initializatize(this);
    }

    //Проверка хватит ли валюты
    public bool IsEnoughtCurrency(int value)
    {
        //return repository.CurrrencyValue >= value;
        return CurrencyValue >= value;
    }

    //Добавить валюту с указанием отправителя
    public void AddCurrency(object sender, int value)
    {
        //sender оправитель
        _repository.CurrencyValue += value;
        _repository.Save();
    }

    //Потратить валюту с указанием отправителя
    public void SpendCurrency(object sender, int value)
    {
        //sender оправитель
        _repository.CurrencyValue -= value;
        _repository.Save();
    }
}
