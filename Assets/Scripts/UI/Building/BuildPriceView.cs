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
        _oreView.WriteInField(price.Ore);
        _woodView.WriteInField(price.Wood);
        _foodView.WriteInField(price.Food);
        _crystalView.WriteInField(price.Crystal);
    }

    [System.Serializable]
    class PriceView
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private GameObject _parent;

        public void WriteInField(int value)
        {
            if (value > 0)
            {
                _label.text = value.ToString();
            }
            else
            {
                _parent.SetActive(false);
            }
        }
    }
}
