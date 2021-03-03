using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingMinedResourceToPurse : MonoBehaviour
{
    [SerializeField] private PlaceLogic _placeLogic;
    [SerializeField] private Purse _purse;

    private void OnEnable()
    {
        _placeLogic.SmashedBuilding += OnPlacedNewBuilding;
    }

    private void Start()
    {
        var buildings = FindObjectsOfType<BuildingResourceContainer>();
        foreach(var building in buildings)
        {
            building.Mined += OnMinedResources;
        }
    }

    private void OnDisable()
    {
        _placeLogic.SmashedBuilding -= OnPlacedNewBuilding;
    }

    private void OnPlacedNewBuilding(Building building)
    {
        if(building.TryGetComponent(out BuildingResourceContainer buildingContainer))
        {
            buildingContainer.Mined += OnMinedResources;
        }
        else
        {
            throw new System.Exception("Building dont have building container");
        }
    }

    private void OnMinedResources(Resources resources)
    {
        _purse.AddResources(resources);
    }
}
