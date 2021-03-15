using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellerMovingToResource : FellerState
{
    [SerializeField] private State _onComeToTarget;
    [SerializeField] private State _onNoTargets;
    [SerializeField] private float _stopDistance;

    private ResourceSource _currentTarget;
    private bool _isActive = false;

    private void OnEnable()
    {
        _isActive = true;
        _currentTarget = _erner.GetSource();

        _animator.SetBool(_walkingHash, true);
        _animator.SetBool(_miningHash, false);

        _navAgent.enabled = true;
        if (_currentTarget == null || _currentTarget.IsDestroy)
        {
            SetNewTarget();
        }
        else
        {
            _navAgent.SetDestination(_currentTarget.transform.position);
        }
    }

    private void Update()
    {
        if (_currentTarget != null)
        {
            if (Vector3.Distance(transform.position, _currentTarget.transform.position) < _stopDistance)
            {
                _navAgent.enabled = false;
                Vector3 target2d = _currentTarget.transform.position;
                target2d.y = transform.position.y;
                transform.rotation = Quaternion.LookRotation(target2d - transform.position);
                _isActive = false;
                NeedTransition(_onComeToTarget);
            }
        }
        else
        {
            SetNewTarget();
        }
    }

    private void SetNewTarget()
    {
        _currentTarget = _erner.GetSource();

        if (_currentTarget != null)
        {
            if (_isActive)
            {
                if (_currentTarget.IsDestroy == false)
                {
                    _navAgent.enabled = true;
                    _navAgent.SetDestination(_currentTarget.transform.position);
                }
            }
        }
        else
        {
            NeedTransition(_onNoTargets);
        }
    }
}
