using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimatorController : MonoBehaviour
{
    [SerializeField] Animator animator;

    private string[] parametrs = { "Idle", "Reload", "Fire", "Moving"};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void StopReloading()
    {
        animator.SetBool(parametrs[1], false);
        animator.SetBool(parametrs[0], true);
    }

    public void StartReload()
    {
        for (int i = 0; i < parametrs.Length; i++)
        {
            animator.SetBool(parametrs[i], false);
        }
        animator.SetBool(parametrs[1], true);
    }

    public void ChangeGunState(bool activate)
    {
        //if(!activate)
        //{
        //    animator.SetBool("Idle", true);
        //}
        animator.enabled = activate;

    }

    public void ChangeMoving(bool start)
    {
        for (int i = 0; i < parametrs.Length; i++)
        {
            animator.SetBool(parametrs[i], false);
        }
        if (start)
        {
            animator.SetBool(parametrs[3], start);
        }
        else
        {
            animator.SetBool(parametrs[0], true);
        }
    }

    public void ChangeFire(bool start)
    {
        for (int i = 0; i < parametrs.Length; i++)
        {
            animator.SetBool(parametrs[i], false);
        }
        if (start)
        {
            animator.SetBool(parametrs[2], start);
        }
        else
        {
            animator.SetBool(parametrs[0], true);
        }
    }

    
}
