using System;
using System.Collections.Generic;

public class FinalStateMashine 
{
    private FSMState StateCurrent { get; set; }
    private Dictionary<Type, FSMState> _states = new Dictionary<Type, FSMState>();

    public void AddState<T>(T state) where T : FSMState
    {
        _states.Add(typeof(T), state);
    }

    public void SetState<T>() where T : FSMState
    {
        var type = typeof(T);

        if(StateCurrent != null && StateCurrent.GetType() == type)
        {
            return;
        }

        if(_states.TryGetValue(type, out var newState))
        {
            StateCurrent?.Exit();

            StateCurrent = newState;

            StateCurrent.Enter();
        }    
    }

    public void Update()
    {
        StateCurrent?.Update();
    }
}
