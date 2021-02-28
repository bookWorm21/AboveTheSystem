using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaracksPanel : ProducingUnitsPanel
{
    protected override BuildingInfoForView[] FindStandingBuildings()
    {
        return FindObjectsOfType<BaracksInfoForView>();
    }
}
