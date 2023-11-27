using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBulletForward : MonoBehaviour, IMovingBullet
{
    public void MoveBullet(float speed)
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
