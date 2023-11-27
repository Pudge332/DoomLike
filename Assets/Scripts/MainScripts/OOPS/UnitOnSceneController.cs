using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitOnSceneController : MonoBehaviour
{
    public static UnitOnSceneController Instance;
    public static UnityEvent<int> OnUnitDie = new UnityEvent<int>();
    [SerializeField] List<Unit> allLiveUnitsOnScene = new List<Unit>();
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void RegistrNewUnitOnScene(Unit newUnit)
    {
        allLiveUnitsOnScene.Add(newUnit);
    }
    public void SendEnemyDie(int idUnit, Unit deadUnit)
    {
        OnUnitDie.Invoke(idUnit);
        RemoveUnitOnDie(deadUnit);
        Destroy(deadUnit.gameObject);
    }

    private void RemoveUnitOnDie(Unit deadUnit)
    {
        allLiveUnitsOnScene.Remove(deadUnit);
        Destroy(deadUnit.gameObject);
    }
}
