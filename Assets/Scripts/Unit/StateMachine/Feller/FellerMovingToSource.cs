using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellerMovingToSource : FellerState
{
    [SerializeField] private ErnerResourceContainer _container;
    [SerializeField] private float _stopDistance;
    [SerializeField] private State _onComeToSource;
    [SerializeField] private State _onNoSource;

    private BuildingResourceContainer _salePoint;

    private void OnEnable()
    {
        _salePoint = _erner.GetSalePoint();
        _navAgent.enabled = true;

        if(_salePoint == null)
        {
            _salePoint = _erner.GetSalePoint();
        }

        if (_salePoint != null)
        {
            _animator.SetBool(_miningHash, false);
            _animator.SetBool(_walkingHash, true);
            _navAgent.SetDestination(_salePoint.transform.position);
        }
        else
        {
            NeedTransition(_onNoSource);
        }
    }

    private void FixedUpdate()
    {
        if (_salePoint != null)
        {
            if (Vector3.Distance(transform.position, _salePoint.transform.position) < _stopDistance)
            {
                _navAgent.enabled = false;
                Vector3 target2d = _salePoint.transform.position;
                target2d.y = transform.position.y;
                transform.rotation = Quaternion.LookRotation(target2d - transform.position);

                _salePoint.Pick(_container.GetAccumulated());
                NeedTransition(_onComeToSource);
            }
        }
        else
        {
            _salePoint = _erner.GetSalePoint();

            if (_salePoint == null)
            {
                NeedTransition(_onNoSource);
            }
            else
            {
                _navAgent.SetDestination(_salePoint.transform.position);
            }
        }
    }
}
