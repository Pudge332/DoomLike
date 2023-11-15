using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyItNow : MonoBehaviour
{
    [SerializeField] public float timer;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyNowGameObject", timer);
    }

    private void DestroyNowGameObject()
    {
        Destroy(gameObject);
    }
}
