using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] float fireRate;
    [SerializeField] GunAnimatorController gunAnimatorController;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform startBulletPos;
    [SerializeField] Transform[] drobPositions;
    [SerializeField] ParticleSystem[] effectFiering;
    [SerializeField] int setCurrentBullets;
    
    [SerializeField] private bool isFire = false;
    [SerializeField] private bool reloading = false;
    [SerializeField] private int currentBullets = 0;
    private float nextTimeToFire = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentBullets = setCurrentBullets;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if ((!reloading) && (currentBullets > 0))
            {
                isFire = true;
                EffectChangeState(true);
                gunAnimatorController.ChangeFire(true);
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (!reloading)
            {
                EffectChangeState(false);
                isFire = false;
                gunAnimatorController.ChangeFire(false);
            }
        }

        if((Input.GetKeyDown(KeyCode.R)) || ((!reloading) && (currentBullets == 0)))
        {
            SStartReload();
        }

        if((isFire) && (!reloading))
        {
            FireControll();
        }

    }

    private void EffectChangeState(bool activate)
    {
        if(activate)
        {
            foreach(ParticleSystem effect in effectFiering)
            {
                if(!effect.isPlaying)
                {
                    effect.Play();
                }
            }
        }
        else
        {
            foreach (ParticleSystem effect in effectFiering)
            {
                effect.Stop();
            }
        }
    }

    public void ChangeAnimatorState(bool activate)
    {
        gunAnimatorController.ChangeGunState(activate);
    }
    public void SStartReload()
    {
        isFire = false;
        EffectChangeState(false);
        reloading = true;
        gunAnimatorController.StartReload();
    }
    public void StopReload()
    {
        reloading = false;
        gunAnimatorController.StopReloading();
        currentBullets = setCurrentBullets;
    }
    public void MovingSost(bool moving)
    {
        if ((!isFire) && (!reloading))
        {
            gunAnimatorController.ChangeMoving(moving);
        }
    }
    private void FireControll()
    {
        if (currentBullets > 0)
        {
            if (Time.time >= nextTimeToFire)
            {
                currentBullets--;
                nextTimeToFire = Time.time + 1f / fireRate;
                Fire();
            }
        }
    }
    private void Fire()
    {
        //Debug.Log("SPAWN BULLET");
        GameObject bulletOnScene = Instantiate(bullet, startBulletPos.position, startBulletPos.rotation);
        if(drobPositions != null)
        {
            foreach (Transform bulletPos in drobPositions)
            {
                GameObject drobBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            }
        }
    }
}
