using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingViewOnSelected : MonoBehaviour
{
    [SerializeField] private SellingBuildings _sellingBuildings;
    [SerializeField] private ObjectPriceView _priceView;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellBuildingButton;

    private Resources _startBuildingPrice;
    private Resources _currentBuildingPrice;

    private void Start()
    {
        _sellBuildingButton.onClick.AddListener(() =>
        {
            _sellingBuildings.SellCurrentBuilding(_currentBuildingPrice);
        });
    }

    public void Present(BuildingProfile profile)
    {
        _startBuildingPrice = profile.Price * 0.5f;
        _priceView.Present(_startBuildingPrice);
        _name.text = profile.Name;
        _icon.sprite = profile.Icon;
    }

    public void BuildingHealthChange(float normalizedValue)
    {
        _currentBuildingPrice = _startBuildingPrice * normalizedValue;
        _priceView.Present(_currentBuildingPrice);
    }
}
