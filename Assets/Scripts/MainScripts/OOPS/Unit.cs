using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] float healthsUnitSF;
    [SerializeField] int idUnitSF;
    [SerializeField] float speedMovingUnitSF;
    protected float healths { get; set; }
    protected float currentHealths { get; set; }
    protected float speedMoving { get; set; }
    protected int unitId { get; set; }
    private void Start()
    {
        InitializeUnit(healthsUnitSF, idUnitSF, speedMovingUnitSF);
    }
    public void InitializeUnit(float healthsUnit, int idUnit, float unitSpeedMoving)
    {
        healths = healthsUnit;
        currentHealths = healths;
        unitId = idUnit;
        speedMoving = unitSpeedMoving;
        UnitOnSceneController.Instance.RegistrNewUnitOnScene(this);
    }
    public virtual float TakeDamage(float damage)
    {
        currentHealths -= damage;
        if(currentHealths <= 0)
        {
            UnitDie();
        }
        return currentHealths;
    }

    private void UnitDie()
    {
        UnitOnSceneController.Instance.SendEnemyDie(unitId, this);
    }

    
}
