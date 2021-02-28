using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawmillPanel : ProducingUnitsPanel
{
    protected override BuildingInfoForView[] FindStandingBuildings()
    {
        return FindObjectsOfType<SawmillInfo>();
    }
}
