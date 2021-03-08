using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceBuildingForProduction : MonoBehaviour
{
    [SerializeField] private HelpChosenPanel _helpPanel;
    [SerializeField] private LayerMask _buildingMask;

    private Camera _main;

    public BuildingInfoForView Current { get; private set; }

    private void Start()
    {
        _main = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = _main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit result, 100, _buildingMask))
            {
                if(result.transform.gameObject.TryGetComponent(out BuildingInfoForView production))
                {
                    if(production.IsInit)
                    {
                        Current = production;
                        production.Click();
                        _helpPanel.OnClickAtBuilding(production);
                    }
                }
            }
        }
    }
}
