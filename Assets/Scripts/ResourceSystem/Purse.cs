using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purse : MonoBehaviour
{
    [SerializeField] private PlaceLogic _placeLogic;
    [SerializeField] private Resources _playerResources;

    private Building _current;
    private Resources _emptyResources;

    public System.Action<Resources> ChangedResources;

    private void OnEnable()
    {
        _placeLogic.SmashedBuilding += OnSmashBuild;    
    }

    private void Start()
    {
        ChangedResources?.Invoke(_playerResources);
        _emptyResources = Resources.GetEmpty();
    }

    private void OnDisable()
    {
        _placeLogic.SmashedBuilding -= OnSmashBuild;
    }

    public void BuyBuilding(Building building)
    {
        _current = building;

        if (_playerResources >= _current.Profile.Price)
        {
            _placeLogic.SelectBuilding(building);
        }
        else
        {
            Debug.Log("не хватает ресурсов");
        }
    }

    public void AddResources(Resources resources)
    {
        if(resources >= _emptyResources)
        {
            _playerResources += resources;
            ChangedResources?.Invoke(_playerResources);
        }
        else
        {
            throw new System.Exception();
        }
    }

    private void OnSmashBuild(Building building)
    {
        if (building != _current)
            throw new System.Exception();

        _playerResources -= building.Profile.Price;
        ChangedResources?.Invoke(_playerResources);
    }
}
