using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceBuildingForProduction : MonoBehaviour
{
    [SerializeField] private HelpChosenPanel _helpPanel;
    [SerializeField] private LayerMask _buildingMask;

    private Camera _main;

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
                if(result.transform.gameObject.TryGetComponent(out BuildingProductionCooldown production))
                {
                    if(production.IsInit)
                    {
                        production.Click();
                        _helpPanel.OnClickAtBuilding(production);
                    }
                }
            }
        }
    }
}
