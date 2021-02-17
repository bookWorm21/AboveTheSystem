using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitProfle : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private Resources _price;
    [SerializeField] private float _productionTime;
    [SerializeField] private string _name;
    [SerializeField] private int _health;

    public Sprite Icon => _icon;

    public float ProductionTime => _productionTime;
    public string Name => _name;

    public Resources Price => _price;

    public int Health => _health;
}
