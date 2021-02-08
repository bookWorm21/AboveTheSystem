using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurseResourceView : MonoBehaviour
{
    [SerializeField] private Purse _playerPurse;

    [Space(order = 15)]
    [InspectorName("Views")]
    [SerializeField] private PriceView _oreView;
    [SerializeField] private PriceView _woodView;
    [SerializeField] private PriceView _crystalView;
    [SerializeField] private PriceView _foodView;

    private void OnEnable()
    {
        _playerPurse.ChangedResources += OnResourcesChange;
    }

    private void OnDisable()
    {
        _playerPurse.ChangedResources -= OnResourcesChange;    
    }

    private void OnResourcesChange(Resources resources)
    {
        _oreView.WriteInField(resources.Ore);
        _woodView.WriteInField(resources.Wood);
        _foodView.WriteInField(resources.Food);
        _crystalView.WriteInField(resources.Crystal);
    }
}
