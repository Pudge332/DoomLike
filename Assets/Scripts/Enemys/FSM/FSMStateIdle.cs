using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMStateIdle : FSMState
{
    private const string IdleAnimName = "Idle";
    public FSMStateIdle(FinalStateMashine fsm, Animator animator) : base(fsm, animator) { }

    public override void Enter()
    {
        _animator.SetBool(IdleAnimName, true);
        Debug.Log("Idle state [ENTER]");
    }

    public override void Exit()
    {
        _animator.SetBool(IdleAnimName, false);
        Debug.Log("Idle state [EXIT]");
    }

    public override void Update()
    {
        Debug.Log("Idle Wait");
    }
}
