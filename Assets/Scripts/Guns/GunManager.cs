using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] GunController[] guns;
    [SerializeField] GameObject[] gunsObj;
    private int currentGun = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetGun(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchGun(0);
            SetGun(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchGun(1);
            SetGun(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchGun(2);
            SetGun(2);
        }

    }

    private void DeactivateGunAnimator()
    {
        guns[currentGun].ChangeAnimatorState(false);
    }

    private void SwitchGun(int newIndex)
    {
        DeactivateGunAnimator();
        currentGun = newIndex;
    }

    public void ChangeMovingSost(bool start)
    {
        guns[currentGun].MovingSost(start);
    }
    private void SetGun(int idGun)
    {
        int index = 0;
        foreach(GameObject gun in gunsObj)
        {
            if (index != idGun)
            {
                gun.gameObject.SetActive(false);
            }
            else
            {
                gun.gameObject.SetActive(true);
                guns[currentGun].ChangeAnimatorState(true);
            }
            index++;
        }
    }
}
