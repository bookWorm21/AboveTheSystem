using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new BuildProfile", menuName = "Building/create building", order = 51)]
public class BuildingProfile : ScriptableObject
{
    [SerializeField] private UnitProfile[] _productionUnits;
    [SerializeField] private Resources _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _health;
    [SerializeField] private string _name;
    [SerializeField] private string _description;

    public Resources Price => _price;

    public Sprite Icon => _icon;

    public float Health => _health;

    public string Name => _name;

    public string Description => _description;

    public UnitProfile GetUnit(int index)
    {
        if(index >= 0 && index < _productionUnits.Length)
        {
            return _productionUnits[index];
        }
        else
        {
            throw new System.Exception("index out in array");
        }
    }

    public int GetCountUnitInProduction()
    {
        return _productionUnits.Length;
    }

}
