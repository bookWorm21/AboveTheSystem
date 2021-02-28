using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPanel : ProducingUnitsPanel
{
    protected override BuildingInfoForView[] FindStandingBuildings()
    {
        return FindObjectsOfType<FarmInfoForView>();
    }
}
