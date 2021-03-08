using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellerMovingToSource : FellerState
{
    [SerializeField] private FellerResourceContainer _container;
    [SerializeField] private float _stopDistance;
    [SerializeField] private State _onComeToSource;
    [SerializeField] private State _onNoSource;

    private BuildingResourceContainer _source;

    private void OnEnable()
    {
        _source = _feller.GetSource();
        _navAgent.enabled = true;

        if(_source == null)
        {
            _source = WoodResources.Instance.GetNearSource(transform.position);
            _feller.SetSource(_source);
        }

        if (_source != null)
        {
            _animator.SetBool(_miningHash, false);
            _animator.SetBool(_walkingHash, true);
            _navAgent.SetDestination(_source.transform.position);
        }
        else
        {
            WoodResources.Instance.AddInWaitingList(_feller);
            NeedTransition(_onNoSource);
        }
    }

    private void FixedUpdate()
    {
        if (_source != null)
        {
            if (Vector3.Distance(transform.position, _source.transform.position) < _stopDistance)
            {
                _navAgent.enabled = false;
                Vector3 target2d = _source.transform.position;
                target2d.y = transform.position.y;
                transform.rotation = Quaternion.LookRotation(target2d - transform.position);

                _source.Pick(_container.GetAccumulated());
                NeedTransition(_onComeToSource);
            }
        }
        else
        {
            _source = WoodResources.Instance.GetNearSource(transform.position);
            if (_source == null)
            {
                WoodResources.Instance.AddInWaitingList(_feller);
                NeedTransition(_onNoSource);
            }
            else
            {
                _navAgent.SetDestination(_source.transform.position);
            }
        }
    }
}
