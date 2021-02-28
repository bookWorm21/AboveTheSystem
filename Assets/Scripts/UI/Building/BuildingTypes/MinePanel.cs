using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinePanel : ProducingUnitsPanel
{
    protected override BuildingInfoForView[] FindStandingBuildings()
    {
        return FindObjectsOfType<MineInfo>();
    }
}
