using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new BuildProfile", menuName = "Building/create building", order = 51)]
public class BuildingProfile : ScriptableObject
{
    [SerializeField] private Resources _price;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;

    public Resources Price => _price;

    public string Name => _name;

    public string Description => _description;

    public Sprite Icon => _icon;
}
