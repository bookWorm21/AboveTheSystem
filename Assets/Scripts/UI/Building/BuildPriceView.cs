using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildPriceView : MonoBehaviour
{
    [SerializeField] private PriceView _oreView;
    [SerializeField] private PriceView _woodView;
    [SerializeField] private PriceView _foodView;
    [SerializeField] private PriceView _crystalView;

    public void Present(Resources price)
    {
        TryWriteInField(price.Ore, _oreView);
        TryWriteInField(price.Wood, _woodView);
        TryWriteInField(price.Food, _foodView);
        TryWriteInField(price.Crystal, _crystalView);
    }

    private void TryWriteInField(int value, PriceView view)
    {
        if(value > 0)
        {
            view.WriteInField(value);
        }
        else
        {
            view.DeleteField();
        }
    }
}
