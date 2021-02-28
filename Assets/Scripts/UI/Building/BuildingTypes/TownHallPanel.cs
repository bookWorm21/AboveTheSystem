using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHallPanel : SelectedTypeBuildingPanel
{
    protected override BuildingInfoForView[] FindStandingBuildings()
    {
        return FindObjectsOfType<TownHallInfo>();
    }

    protected override void InitStandingBuildings()
    {
        
    }

    protected override void InitUIElements(BuildingProfile profile)
    {
        
    }

    protected override void UpdateUI()
    {
        
    }
}
