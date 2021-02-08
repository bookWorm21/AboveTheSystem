using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpChosenPanel : MonoBehaviour
{
    [SerializeField] private GameObject _buildingListPanel;
    [SerializeField] private GameObject _startBuildingListPanel;
    [SerializeField] private GameObject _panelForCancelPlacing;
    [SerializeField] private PlaceLogic _placeLogic;

    private GameObject _currentBuildPanel;

    private void OnEnable()
    {
        _placeLogic.StartedPlacing += OnStartPlacing;
        _placeLogic.EndedPlacing += OnEndPlacing;
        _placeLogic.SmashedBuilding += OnPlaceFirstBuild;
    }

    private void Start()
    {
        _buildingListPanel.SetActive(false);
        _startBuildingListPanel.SetActive(false);

        _currentBuildPanel = _startBuildingListPanel;
        OnEndPlacing();
    }

    private void OnDisable()
    {
        _placeLogic.StartedPlacing -= OnStartPlacing;
        _placeLogic.EndedPlacing -= OnEndPlacing;

        _placeLogic.SmashedBuilding -= OnPlaceFirstBuild;
    }

    public void OnClickOpenBuildingButton()
    {
        _currentBuildPanel.SetActive(true);
    }

    public void OnClickCloseBuildingButton()
    {
        _currentBuildPanel.SetActive(false);
    }

    private void OnPlaceFirstBuild(Building building)
    {
        _startBuildingListPanel.SetActive(false);
        _buildingListPanel.SetActive(true);
        _currentBuildPanel = _buildingListPanel;
        _placeLogic.SmashedBuilding -= OnPlaceFirstBuild;
    }

    private void OnStartPlacing()
    {
        _panelForCancelPlacing.SetActive(true);
    }

    private void OnEndPlacing()
    {
        _panelForCancelPlacing.SetActive(false);
    }
}
