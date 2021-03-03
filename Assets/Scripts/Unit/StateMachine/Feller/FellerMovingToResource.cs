using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellerMovingToResource : FellerState
{
    [SerializeField] private State _onComeToTarget;
    [SerializeField] private State _onTargetDestroyed;
    [SerializeField] private float _stopDistance;

    private Tree _currentTarget;

    private void OnEnable()
    {
        _navAgent.enabled = true;
        _currentTarget = _feller.GetTarget();

        _animator.SetBool(_walkingHash, true);
        _animator.SetBool(_miningHash, false);

        if (_currentTarget == null || _currentTarget.IsDestroy)
        {
            SetNewTarget();
        }
        else
        {
            _currentTarget.Destroed += SetNewTarget;
            _navAgent.SetDestination(_currentTarget.transform.position);
        }
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, _currentTarget.transform.position) < _stopDistance)
        {
            _navAgent.enabled = false;
            Vector3 target2d = _currentTarget.transform.position;
            target2d.y = transform.position.y;
            transform.rotation = Quaternion.LookRotation(target2d - transform.position);
            NeedTransition(_onComeToTarget);
        }
    }

    private void SetNewTarget()
    {
        if(_currentTarget != null)
        {
            _currentTarget.Destroed -= SetNewTarget;
        }

        _currentTarget = WoodResources.Instance.GetNearTree(transform.position);
        _feller.SetTarget(_currentTarget);

        if (_currentTarget != null)
        {
            if (_currentTarget.IsDestroy == false)
            {
                _currentTarget.Destroed += SetNewTarget;
                _navAgent.enabled = true;
                _navAgent.SetDestination(_currentTarget.transform.position);
            }
        }
        else
        {
            //afke
        }
    }
}
