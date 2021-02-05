using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new BuildProfile", menuName = "Building/create building", order = 51)]
public class BuildingProfile : ScriptableObject
{
    [SerializeField] private int _price;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;

    public int Price => _price;

    public string Name => _name;

    public Sprite Icon => _icon;
}
