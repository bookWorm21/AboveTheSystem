using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBuyButton : MonoBehaviour
{
    [SerializeField] private BuildingButtonView _buttonView;
    [SerializeField] private Building _building;
    [SerializeField] private SelectedTypeBuildingPanel _panel;
    [SerializeField] private UnityEngine.UI.Button _button;

    private PayerPerBuilding _payer;
    private PlaceLogic _placeLogic;

    public void OnGameStart(Purse purse, PayerPerBuilding payer, PlaceLogic placeLogic)
    {
        _payer = payer;
        _placeLogic = placeLogic;

        _buttonView.Present(_building.Profile);
        _button.onClick.AddListener(() =>
        {
            _payer.BuyBuilding(_building);
            _placeLogic.SetPanelForCurrentBuilding(_panel);
        });

        _panel.OnGameStart(purse, _building.Profile);
    }
}
