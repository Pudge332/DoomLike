using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMovingBullet))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] IMovingBullet bulletMover;
    [SerializeField] float speedBullet;
    [SerializeField] float damage;

    private void Awake()
    {
        bulletMover = GetComponent<IMovingBullet>();
    }
    void Update()
    {
        bulletMover.MoveBullet(speedBullet);
    }

    protected virtual void OnTakeDamage()
    {
        Destroy(gameObject);
    }

    protected virtual void OnCollisionWall()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Unit>(out Unit unitOnScene))
        {
            float leftHp = unitOnScene.TakeDamage(damage);
            Debug.Log($"{leftHp}  {unitOnScene.GetType()}");
            OnTakeDamage();
        }
        else
        {
            OnCollisionWall();
        }
    }
}
