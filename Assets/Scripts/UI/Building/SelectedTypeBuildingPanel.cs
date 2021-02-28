using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SelectedTypeBuildingPanel : MonoBehaviour
{
    [SerializeField] private BuildingViewOnSelected _buildingView;

    protected BuildingInfoForView _current;

    protected Purse _purse;

    public void OnGameStart(Purse purse, BuildingProfile profile)
    {
        _purse = purse;
        _buildingView.Present(profile);

        InitStandingBuildings();
        InitUIElements(profile);
    }

    public void OnBuildingHealthChange(float normailizedValue)
    {
        _buildingView.BuildingHealthChange(normailizedValue);
    }

    public void OnClickAtBuilding(BuildingInfoForView production)
    {
        if (_current != production)
        {
            if (_current != null)
            {
                _current.UnFocus();
            }

            UpdateUI();

            _current = production;
        }
    }

    protected abstract void InitUIElements(BuildingProfile profile);

    protected abstract void InitStandingBuildings();

    protected abstract void UpdateUI();

    protected abstract BuildingInfoForView[] FindStandingBuildings();
}
