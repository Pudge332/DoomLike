using UnityEngine;

public abstract class FSMState {

    protected readonly FinalStateMashine _Fsm;
    protected readonly Animator _animator;
    public FSMState(FinalStateMashine fsm, Animator animator)
    {
        _Fsm = fsm;
        _animator = animator;
    }
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}
