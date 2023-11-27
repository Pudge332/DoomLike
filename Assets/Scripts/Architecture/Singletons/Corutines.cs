using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Corutines : MonoBehaviour //sealed == нельзя наследоваться от класса
{
    private static Corutines instance
    {
        get
        {
            if(m_instance == null)
            {
                GameObject corutineControllerGO = new GameObject(name:"CorutineController");
                m_instance = corutineControllerGO.AddComponent<Corutines>();
                DontDestroyOnLoad(corutineControllerGO);
            }
            return m_instance;
        }
    }
    private static Corutines m_instance;

    public static Coroutine StartIncomingCorutine(IEnumerator enumerator)
    {
        return instance.StartCoroutine(enumerator);
    }

    public static void StopIncomingCorutine(IEnumerator enumerator)
    {
        instance.StopCoroutine(enumerator);
    }
}
