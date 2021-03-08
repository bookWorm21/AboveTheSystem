using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellingBuildings : MonoBehaviour
{
    [SerializeField] private HelpChosenPanel _helpPanel;
    [SerializeField] private ChoiceBuildingForProduction _choiceBuilding;
    [SerializeField] private Purse _purse;

    public void SellCurrentBuilding(Resources price)
    {
        BuildingInfoForView current = _choiceBuilding.Current;
        if (current != null)
        {
            _helpPanel.OnSellCurrentBuilding();
            current.GetComponent<BuildingDestructibility>().Destroy();
            _purse.AddResources(price);
        }
    }
}
