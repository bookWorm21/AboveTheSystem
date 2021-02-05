using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceLogic : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private LayerMask _buildingMask;

    private BuildingGhost _currentBuilding;
    private Camera _main;

    private bool _selected = false;

    public bool IsConstruction { get; private set; }

    private void Start()
    {
        _main = Camera.main;
    }

    private void Update()
    {
        if(_currentBuilding != null)
        {
            if(_selected)
            {
                Ray ray = _main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit result, 100, _groundMask))
                {
                    Vector3 worldPosition = result.point;
                    worldPosition.x = Mathf.RoundToInt(worldPosition.x);
                    worldPosition.z = Mathf.RoundToInt(worldPosition.z);
                    _currentBuilding.transform.position = worldPosition;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    if(_currentBuilding.IsCollisied == false)
                    {
                        _currentBuilding.Place();
                    }
                    else
                    {
                        EndConstruction();
                    }

                    IsConstruction = false;
                    _selected = false;
                }
            }
            else if(Input.GetMouseButtonDown(0))
            {
                Ray ray = _main.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out RaycastHit result, 100, _buildingMask))
                {
                    if(result.collider.gameObject.TryGetComponent(out BuildingGhost _))
                    {
                        _selected = true;
                    }
                    else
                    {
                        EndConstruction();
                    }
                }
                else
                {
                    EndConstruction();
                }
            }
        }
    }

    public void SelectBuilding(BuildingGhost building)
    {
        if(_currentBuilding != null)
        {
            EndConstruction();
        }

        IsConstruction = true;
        _selected = false;
        _currentBuilding = Instantiate(building);

        Ray ray = _main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 10));

        if(Physics.Raycast(ray, out RaycastHit result, 100, _groundMask))
        {
            Vector3 worldPosition = result.point;
            _currentBuilding.transform.position = worldPosition;
        }
    }

    private void EndConstruction()
    {
        _selected = false;
        IsConstruction = false;
        Destroy(_currentBuilding.gameObject);
    }
}
