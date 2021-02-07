using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceLogic : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private LayerMask _buildingMask;

    private Building _currentBuilding;
    private BuildingGhost _currentBuildingGhost;
    private Camera _main;

    public bool IsSelected { get; private set; }

    public bool IsConstruction { get; private set; }

    public event System.Action StartedPlacing;

    public event System.Action EndedPlacing;

    public event System.Action<Building> SmashedBuilding;

    private void Start()
    {
        _main = Camera.main;
    }

    private void Update()
    {
        if(_currentBuildingGhost != null)
        {
            Ray ray = _main.ScreenPointToRay(Input.mousePosition);

            Ray centerScreen = _main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 10));
            ArrangeInGround(centerScreen);

            if (IsSelected)
            {
                ArrangeInGround(ray);

                if (Input.GetMouseButtonUp(0))
                {
                    if(_currentBuildingGhost.IsCollisied == false)
                    {
                        SmashedBuilding?.Invoke(_currentBuilding);
                        _currentBuildingGhost.Place();
                        EndedPlacing?.Invoke();
                    }
                    else
                    {
                        EndConstruction();
                    }

                    IsConstruction = false;
                    IsSelected = false;
                }
            }
            else if(Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out RaycastHit result, 100, _buildingMask))
                {
                    if(result.collider.gameObject.TryGetComponent(out BuildingGhost _))
                    {
                        IsSelected = true;
                    }
                    else
                    {
                        EndConstruction();
                    }
                }
            }
        }
    }

    public void SelectBuilding(Building building)
    {
        if(_currentBuildingGhost != null)
        {
            EndConstruction();
        }

        StartedPlacing?.Invoke();

        IsConstruction = true;
        IsSelected = false;
        _currentBuilding = building;
        _currentBuildingGhost = Instantiate(building.Ghost);

        Ray ray = _main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 10));

        ArrangeInGround(ray);
    }

    public void EndConstruction()
    {
        EndedPlacing?.Invoke();
        IsSelected = false;
        IsConstruction = false;
        Destroy(_currentBuildingGhost.gameObject);
    }
    
    private void ArrangeInGround(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit result, 100, _groundMask))
        {
            Vector3 worldPosition = result.point;
            worldPosition.x = Mathf.RoundToInt(worldPosition.x);
            worldPosition.z = Mathf.RoundToInt(worldPosition.z);
            _currentBuildingGhost.transform.position = worldPosition;
        }
    }

}
