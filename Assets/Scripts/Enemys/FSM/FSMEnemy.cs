using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMEnemy : MonoBehaviour
{
    public static event Action ShellWasCreatedEvent;
    private FinalStateMashine _fsm;
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _upwardShift;
    [SerializeField] private Transform _bodyTransform;
    [SerializeField] private Transform _target;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _attackShell;
    [SerializeField] private Transform _startPosToShell;

    private FSMStateAttack _attackState;

    private void Start()
    {
        _fsm = new FinalStateMashine();

        _fsm.AddState(new FSMStateIdle(_fsm, _animator));
        _fsm.AddState(new FSMStateRun(_fsm, _animator, _speed, _upwardShift, _target, _bodyTransform));
        _attackState = new FSMStateAttack(_fsm, _animator, _target);
        _fsm.AddState(_attackState);

        _fsm.SetState<FSMStateIdle>();
        _attackState.AddListener();
    }

    private void Update()
    {
        _fsm.Update();
    }

    public void CreateShell()
    {
        GameObject shell = Instantiate(_attackShell, _startPosToShell.position, Quaternion.identity);
        shell.transform.LookAt(_target);
        ShellWasCreatedEvent?.Invoke();
    }

    private void OnDestroy()
    {
        _attackState.RemoveListener();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Moving>(out Moving player))
        {
            _fsm.SetState<FSMStateRun>();
        }

        //if(other.transform.parent == _target)
        //{
        //    _fsm.SetState<FSMStateRun>();
        //}
    }
}
