using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBuyButtonInitializer : MonoBehaviour
{
    [SerializeField] private Purse _purse;
    [SerializeField] private PayerPerBuilding _payer;
    [SerializeField] private PlaceLogic _placeLogic;
    [SerializeField] private BuildingBuyButton[] _buyButtons;

    private void Start()
    {
        foreach(var button in _buyButtons)
        {
            button.OnGameStart(_purse, _payer, _placeLogic);
        }
    }
}
