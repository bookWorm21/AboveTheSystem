using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodNavigation : ResourceNavigation
{
    private static WoodNavigation _instance;

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(_instance.gameObject);
        }

        _instance = this;
    }

    public static WoodNavigation GetInstance()
    {
        return _instance;
    }

    protected override BuildingResourceContainer[] FindBuildingContainers()
    {
        SawmillInfo[] sawmills = FindObjectsOfType<SawmillInfo>();
        BuildingResourceContainer[] containers = new BuildingResourceContainer[sawmills.Length];
        for(int i = 0; i < sawmills.Length; i++)
        {
            containers[i] = sawmills[i].GetComponent<BuildingResourceContainer>();
        }

        return containers;
    }

    protected override ResourceSource[] FindResourceSource()
    {
        return FindObjectsOfType<Tree>();
    }

    protected override bool TryGetComponentSpecialContainer(Building building, out BuildingResourceContainer container)
    {
        if(building.TryGetComponent(out SawmillInfo _))
        {
            container = building.GetComponent<BuildingResourceContainer>();
            return true;
        }
        else
        {
            container = null;
            return false;
        }
    }
}
