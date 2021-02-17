using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingViewOnSelected : MonoBehaviour
{
    [SerializeField] private ObjectPriceView _priceView;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellBuilding;

    private Resources _startBuildingPrice;
    private Resources _currentBuildingPrice;

    public void Present(BuildingProfile profile)
    {
        _startBuildingPrice = profile.Price * 0.5f;
        _priceView.Present(_startBuildingPrice);
        _name.text = profile.Name;
        _icon.sprite = profile.Icon;
    }

    public void BuildingHealthChange(float normalizedValue)
    {
        Debug.Log(_startBuildingPrice);
        _currentBuildingPrice = _startBuildingPrice * normalizedValue;
        _priceView.Present(_currentBuildingPrice);
    }
}
