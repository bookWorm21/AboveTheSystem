using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class State : MonoBehaviour
{
    protected Animator _animator;
    protected NavMeshAgent _navAgent;

    public event System.Action<State> NeededTransition;

    public void Init(Animator animator, NavMeshAgent navAgent)
    {
        _animator = animator;
        _navAgent = navAgent;
    }

    public void Enter()
    {
        enabled = true;
    }

    public void Exit()
    {
        enabled = false;
    }

    public void NeedTransition(State nextState)
    {
        NeededTransition?.Invoke(nextState);
    }
}
