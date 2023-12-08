using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMStateAttack : FSMState
{
    protected Transform _target;
    protected const string AttackAnimName = "Attack";
    public FSMStateAttack(FinalStateMashine fsm, Animator animator, Transform target) : base(fsm, animator) {
        _target = target;
    }
    public override void Enter()
    {
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName(AttackAnimName))
        {
            _animator.SetTrigger(AttackAnimName);
        }
    }

    public override void Exit()
    {
        Debug.Log("Idle state [EXIT]");
        //_Fsm.SetState<FSMStateRun>(); //StackOverflow!(пока не понятно почему)
    }

    public void AddListener()
    {
        //FSMEnemy.ShellWasCreatedEvent += Exit;
    }

    public void RemoveListener()
    {
        //FSMEnemy.ShellWasCreatedEvent -= Exit;
    }

    public override void Update()
    {
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName(AttackAnimName)) //Лучше использовать событие на анимации
        {
            _Fsm.SetState<FSMStateRun>();
        }
        if (_target == null)
        {
            _Fsm.SetState<FSMStateIdle>();
            return;
        }
    }
}
