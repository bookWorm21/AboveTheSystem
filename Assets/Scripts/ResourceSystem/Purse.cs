using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purse : MonoBehaviour
{
    [SerializeField] private PlaceLogic _placeLogic;
    [SerializeField] private Resources _playerResources;

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

        if (_playerResources >= building.Profile.Price)
        {
            _placeLogic.SelectBuilding(building);
        }
        else
        {
            Debug.Log("не хватает ресурсов");
        }
    }

    private void OnSmashBuild(Building building)
    {
        if (building != _current)
            throw new System.Exception();

        _playerResources -= building.Profile.Price;
    }
}
