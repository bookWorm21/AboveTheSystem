using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellerIdle : FellerState
{
    [SerializeField] private State _nextState;

    private void OnEnable()
    {
        _animator.SetBool(_miningHash, false);
        _animator.SetBool(_walkingHash, false);
        _navAgent.enabled = false;
    }

    private void Start()
    {
        _feller.PlacedSource += OnPlaceTarget;
    }

    private void OnPlaceTarget(BuildingResourceContainer container)
    {
        _feller.SetSource(container);
        NeedTransition(_nextState);
    }
}
