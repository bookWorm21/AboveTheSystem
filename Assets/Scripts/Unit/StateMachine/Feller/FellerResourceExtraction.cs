using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellerResourceExtraction : FellerState
{
    [SerializeField] private State _onOverflow;
    [SerializeField] private State _onTargetDestroyed;
    [SerializeField] private HitTracker _hitTracker;
    [SerializeField] private FellerResourceContainer _container;
    [SerializeField] private int _maxResourcesInHand;
    [SerializeField] private int _resourcesPerHit;

    private int _currentResources;
    private Tree _currentTarget;

    private void OnEnable()
    {
        _currentResources = _container.CurrentResourcesCount;
        _currentTarget = _feller.GetTarget();
        _animator.SetBool(_miningHash, true);
        _animator.SetBool(_walkingHash, false);
    }

    private void Start()
    {
        _hitTracker.Hitted += HitTree;
        _currentResources = 0;
    }

    private void HitTree()
    {
        if (_currentTarget.IsDestroy == false)
        {
            int hitValue = _currentTarget.ApplyDamage(_resourcesPerHit);
            _container.Add(hitValue);
            _currentResources += hitValue;
            if (_currentResources >= _maxResourcesInHand)
            {
                NeedTransition(_onOverflow);
            }
        }

        if (_currentTarget.IsDestroy)
        {
            NeedTransition(_onTargetDestroyed);
        }
    }
}
