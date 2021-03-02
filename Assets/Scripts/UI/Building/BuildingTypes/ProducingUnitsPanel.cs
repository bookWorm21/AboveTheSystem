using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProducingUnitsPanel : SelectedTypeBuildingPanel
{
    [SerializeField] private UnitButtonView _buttonViewExample;
    [SerializeField] private Transform _parent;

    private UnitButtonView[] _unitButtons;

    public void OnClickBuyUnitButton(UnitButtonView unitButton)
    {
        Debug.Log(unitButton);
        if (_purse.CanBuy(unitButton.Profile.Price))
        {
            Debug.Log("produce");
            ProducingUnitsInfo current = (ProducingUnitsInfo)_current;
            current.Produce(unitButton);
            _purse.Buy(unitButton.Profile.Price);
        }
    }

    protected override void InitUIElements(BuildingProfile profile)
    {
        int unitsCount = profile.GetCountUnitInProduction();
        _unitButtons = new UnitButtonView[unitsCount];

        for (int i = 0; i < unitsCount; i++)
        {
            UnitButtonView unitView = Instantiate(_buttonViewExample, _parent);
            unitView.Present(profile.GetUnit(i));
            _unitButtons[i] = unitView;
        }

        foreach (var unitView in _unitButtons)
        {
            unitView.Clicked += OnClickBuyUnitButton;
        }
    }

    protected override void InitStandingBuildings()
    {
        BuildingInfoForView[] productions = FindStandingBuildings();

        for (int i = 0; i < productions.Length; i++)
        {
            productions[i].Init(this);
        }
    }

    protected override void UpdateUI()
    {
        foreach (var unitButton in _unitButtons)
        {
            unitButton.ResetProgress();
        }
    }
}
