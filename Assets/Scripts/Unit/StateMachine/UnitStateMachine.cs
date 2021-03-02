using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitStateMachine : MonoBehaviour
{
    [SerializeField] private State[] _states;
    [SerializeField] private State _defaultState;
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _navAgent;

    private State _currentState;

    private void OnEnable()
    {
        for(int i = 0; i < _states.Length; i++)
        {
            _states[i].Init(_animator, _navAgent);
            _states[i].NeededTransition += OnNeedTransit;
        }
    }

    private void Start()
    {
        _currentState = _defaultState;
        _defaultState.Enter();
    }

    private void OnNeedTransit(State state)
    {
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    private void OnDisable()
    {
        for (int i = 0; i < _states.Length; i++)
        {
            _states[i].NeededTransition -= OnNeedTransit;
        }
    }
}
