using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerPerBuilding : MonoBehaviour
{
    [SerializeField] private Purse _purse;
    [SerializeField] private PlaceLogic _placeLogic;

    private Building _current;

    private void OnEnable()
    {
        _placeLogic.SmashedBuilding += OnSmashBuild;
    }

    private void OnDisable()
    {
        _placeLogic.SmashedBuilding -= OnSmashBuild;
    }

    public void BuyBuilding(Building building)
    {
        _current = building;

        if (_purse.CanBuy(_current.Profile.Price))
        {
            _placeLogic.SelectBuilding(building);
        }
    }

    private void OnSmashBuild(Building building)
    {
        if (building != _current)
            throw new System.Exception();

        _purse.Buy(building.Profile.Price);
    }
}
