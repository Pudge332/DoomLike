using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMStateRun : FSMState
{
    protected float _speed;
    protected float _upwardShift;
    protected Transform _target;
    protected Transform _transform;
    private float _attackTimer = 0f;
    private int _countFrames = 0;
    private const string RunAnimName = "Run";

    public FSMStateRun(FinalStateMashine fsm, Animator animator, float speed, float upwardShift, Transform target, Transform transform) : base(fsm, animator)
    {
        _speed = speed;
        _target = target;
        _transform = transform;
        _upwardShift = upwardShift;
    }

    public override void Enter()
    {
        Debug.Log("Run state [ENTER]");
        _animator.SetBool(RunAnimName, true);
    }

    public override void Exit()
    {
        Debug.Log("Run state [EXIT]");
        _animator.SetBool(RunAnimName, false);
    }

    public override void Update()
    {
        Debug.Log("Run state [UPDATE]");
        if(_target == null)
        {
            _Fsm.SetState<FSMStateIdle>();
            Debug.Log("Target was destroed");
            return;
        }
        _transform.position = Vector3.MoveTowards(_transform.position, _target.position - 2 * _transform.forward + _upwardShift * _transform.up, _speed * Time.deltaTime);
        Debug.Log("RUN");
        _attackTimer += Time.deltaTime;
        _countFrames += 1;
        if(_attackTimer > 3f)
        {
            _attackTimer = 0f;
            _Fsm.SetState<FSMStateAttack>();
        }
        if(_countFrames > 7)
        {
            _countFrames = 0;
            _transform.LookAt(_target.position);
        }
    }
}
