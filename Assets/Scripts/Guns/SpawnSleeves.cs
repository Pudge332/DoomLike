using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSleeves : MonoBehaviour
{
    [SerializeField] GameObject sleeve;
    [SerializeField] Transform[] positionToSleeve;
    [SerializeField] float force;
    [SerializeField] float torque;
    [SerializeField] float sleeveLifeTime;
    
    
    // Start is called before the first frame update

    public void SpawnSleeve()
    {
        foreach (Transform t in positionToSleeve)
        {
            GameObject sleeveObj = Instantiate(sleeve, t.position, t.rotation);
            sleeveObj.AddComponent<Rigidbody>();
            Rigidbody _rb = sleeveObj.GetComponent<Rigidbody>();
            _rb.drag = 1f;
            _rb.AddForce(Vector3.up * _rb.mass * force);
            _rb.AddRelativeTorque(new Vector3(Random.Range(-torque, torque), Random.Range(-torque, torque), Random.Range(-torque, torque)) * _rb.mass);
            sleeveObj.AddComponent<DestroyItNow>().timer = sleeveLifeTime;
            //sleeveObj.AddComponent<SphereCollider>();
        }
    }
}
