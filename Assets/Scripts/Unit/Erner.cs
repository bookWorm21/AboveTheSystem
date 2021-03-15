using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Erner : Unit
{
    private ResourceNavigation _navigation;

    private ResourceSource _currentTarget;
    private BuildingResourceContainer _currentSalePoint;

    public event System.Action<BuildingResourceContainer> PlacedSource;

    public ResourceSource GetSource()
    {
        if (_currentTarget != null)
        {
            return _currentTarget;
        }
        else
        {
            _currentTarget = _navigation.GetNearSource(transform.position);
            return _currentTarget;
        }
    }

    public BuildingResourceContainer GetSalePoint()
    {
        if(_currentSalePoint != null)
        {
            return _currentSalePoint;
        }
        else
        {
            _currentSalePoint = _navigation.GetNearSalePoint(transform.position);

            if(_currentSalePoint == null)
            {
                _navigation.AddInWaitingList(this);
            }

            return _currentSalePoint;
        }
        
    }

    public void PlaceSource(BuildingResourceContainer salePoint)
    {
        _currentSalePoint = salePoint;
        PlacedSource?.Invoke(salePoint);
    }

    protected override void OnStart()
    {
        _navigation = GetNavigation();
    }

    protected abstract ResourceNavigation GetNavigation();
}
