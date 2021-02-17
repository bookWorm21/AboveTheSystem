using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purse : MonoBehaviour
{
    [SerializeField] private Resources _playerResources;

    private Resources _emptyResources;

    public System.Action<Resources> ChangedResources;

    private void Start()
    {
        ChangedResources?.Invoke(_playerResources);
        _emptyResources = Resources.GetEmpty();
    }

    public void Buy(Resources price)
    {
        if(_playerResources >= price)
        {
            _playerResources -= price;
            ChangedResources?.Invoke(_playerResources);
        }
        else
        {
            throw new System.Exception("not enough money, pre-check required");
        }
    }

    public bool CanBuy(Resources price)
    {
        if(_playerResources >= price)
        {
            return true;
        }
        else
        {
            Debug.Log("не хватает ресурсов");
            return false;
        }
    }

    public void AddResources(Resources resources)
    {
        if(resources >= _emptyResources)
        {
            _playerResources += resources;
            ChangedResources?.Invoke(_playerResources);
        }
        else
        {
            throw new System.Exception();
        }
    }
}
