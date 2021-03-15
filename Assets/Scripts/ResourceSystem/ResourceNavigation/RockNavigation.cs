using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockNavigation : ResourceNavigation
{
    private static RockNavigation _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(_instance.gameObject);
        }

        _instance = this;
    }

    public static RockNavigation GetInstance()
    {
        return _instance;
    }

    protected override BuildingResourceContainer[] FindBuildingContainers()
    {
        MineInfo[] mines = FindObjectsOfType<MineInfo>();
        BuildingResourceContainer[] containers = new BuildingResourceContainer[mines.Length];
        for (int i = 0; i < mines.Length; i++)
        {
            containers[i] = mines[i].GetComponent<BuildingResourceContainer>();
        }

        return containers;
    }

    protected override ResourceSource[] FindResourceSource()
    {
        return FindObjectsOfType<Shaft>();
    }

    protected override bool TryGetComponentSpecialContainer(Building building, out BuildingResourceContainer container)
    {
        if (building.TryGetComponent(out MineInfo _))
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
