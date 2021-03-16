using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitCounter : MonoBehaviour
{
    [SerializeField] private PlaceLogic _placeLogic;
    [SerializeField] private Text _unitCountLabel;

    private int _unitCount = 0;

    private void OnEnable()
    {
        _placeLogic.SmashedBuilding += OnPlaceNewBuild;
    }

    private void OnPlaceNewBuild(Building building)
    {
        if(building.TryGetComponent(out BuildingProduction production))
        {
            production.SpawnedUnit += OnProduceNewUnit;
        }
    }

    private void OnProduceNewUnit(Unit unit)
    {
        _unitCount++;
        _unitCountLabel.text = _unitCount.ToString();
    }

    private void OnDisable()
    {
        _placeLogic.SmashedBuilding -= OnPlaceNewBuild;
    }
}
