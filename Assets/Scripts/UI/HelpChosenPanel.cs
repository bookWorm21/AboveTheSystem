using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HelpChosenPanel : MonoBehaviour
{
    [SerializeField] private GameObject _buildingListPanel;
    [SerializeField] private GameObject _startBuildingListPanel;
    [SerializeField] private GameObject _panelForCancelPlacing;
    [SerializeField] private GameObject _panelForDescription;

    [SerializeField] private PlaceLogic _placeLogic;

    [SerializeField] private TMP_Text _description;

    private GameObject _currentBuildPanel;

    private SelectedTypeBuildingPanel _lastPanel;

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
        _panelForDescription.SetActive(false);

        _currentBuildPanel = _startBuildingListPanel;
        OnEndPlacing();
    }

    private void OnDisable()
    {
        _placeLogic.StartedPlacing -= OnStartPlacing;
        _placeLogic.EndedPlacing -= OnEndPlacing;

        _placeLogic.SmashedBuilding -= OnPlaceFirstBuild;
    }

    public void OnClickAtBuilding(BuildingInfoForView production)
    {
        if(_lastPanel != null)
        {
            _lastPanel.gameObject.SetActive(false);
        }

        _currentBuildPanel.SetActive(false);
        _panelForCancelPlacing.SetActive(true);
        production.ChosenPanel.gameObject.SetActive(true);
        _lastPanel = production.ChosenPanel;
    }

    public void OnClickOpenBuildingButton()
    {
        _currentBuildPanel.SetActive(true);

        if (_lastPanel != null)
        {
            _lastPanel.gameObject.SetActive(false);
        }
    }

    public void OnClickCloseBuildingButton()
    {
        _currentBuildPanel.SetActive(false);
        _panelForDescription.SetActive(false);
    }

    public void OnClickCloseButton()
    {
        if (_lastPanel != null)
        {
            _lastPanel.gameObject.SetActive(false);
        }

        _panelForCancelPlacing.SetActive(false);
    }

    private void OnPlaceFirstBuild(Building building)
    {
        _startBuildingListPanel.SetActive(false);
        _buildingListPanel.SetActive(true);
        _currentBuildPanel = _buildingListPanel;

        _placeLogic.SmashedBuilding -= OnPlaceFirstBuild;
    }

    private void OnStartPlacing(BuildingProfile profile)
    {
        _panelForCancelPlacing.SetActive(true);
        _description.text = profile.Description;
        _panelForDescription.SetActive(true);
    }

    private void OnEndPlacing()
    {
        _panelForCancelPlacing.SetActive(false);
        _panelForDescription.SetActive(false);
    }
}
