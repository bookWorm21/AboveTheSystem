using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feller : Unit
{
    private Tree _currentTarget;
    private BuildingResourceContainer _source;

    public Tree GetTarget()
    {
        return _currentTarget;
    }

    public BuildingResourceContainer GetSource()
    {
        return _source;
    }

    public void SetTarget(Tree target)
    {
        _currentTarget = target;
    }

    public void SetSource(BuildingResourceContainer source)
    {
        _source = source;
    }
}
