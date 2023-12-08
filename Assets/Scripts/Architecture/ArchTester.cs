using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchTester : MonoBehaviour
{
    void Start()
    {
        Game.Run();
    }

    void Update()
    {
        if(!Currency.isInitialized)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Currency.AddCurrency(this, 5);
            Debug.Log($"Add : Currency has {Currency.CurrencyValue}");
        }

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            Currency.Spend(this, 5);
            Debug.Log($"Spend : Currency has {Currency.CurrencyValue}");
        }
    }
}
