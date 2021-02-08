using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class PriceView
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private GameObject _parent;

    public void WriteInField(int value)
    {
        _label.text = value.ToString();
    }

    public void DeleteField()
    {
        _parent.SetActive(false);
    }
}
