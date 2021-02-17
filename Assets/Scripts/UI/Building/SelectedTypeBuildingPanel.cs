using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedTypeBuildingPanel : MonoBehaviour
{
    [SerializeField] private UnitButtonView _buttonViewExample;
    [SerializeField] private BuildingViewOnSelected _buildingView;
    [SerializeField] private Transform _parent;

    private UnitButtonView[] _unitButtons;
    private Purse _purse;
    private BuildingProductionCooldown _current;

    public void OnGameStart(Purse purse, BuildingProfile profile)
    {
        _purse = purse;
        _buildingView.Present(profile);
        BuildingProductionCooldown[] productions = FindObjectsOfType<BuildingProductionCooldown>();
        for (int i = 0; i < productions.Length; i++)
        {
            productions[i].Init(this);
        }

        int unitsCount = profile.GetCountUnitInProduction();
        _unitButtons = new UnitButtonView[unitsCount];

        for (int i = 0; i < unitsCount; i++)
        {
            UnitButtonView unitView = Instantiate(_buttonViewExample, _parent);
            unitView.Present(profile.GetUnit(i));
            _unitButtons[i] = unitView;
        }

        foreach(var unitView in _unitButtons)
        {
            unitView.Clicked += OnClickBuyUnitButton;
        }
    }

    public void OnBuildingHealthChange(float normailizedValue)
    {
        _buildingView.BuildingHealthChange(normailizedValue);
    }

    public void OnClickBuyUnitButton(UnitButtonView unitButton)
    {
        Debug.Log(unitButton);
        if (_purse.CanBuy(unitButton.Profile.Price))
        {
            _current.Produce(unitButton);
            _purse.Buy(unitButton.Profile.Price);
        }
    }

    public void OnClickAtBuilding(BuildingProductionCooldown production)
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

    private void UpdateUI()
    {
        foreach(var unitButton in _unitButtons)
        {
            unitButton.ResetProgress();
        }
    }
}
