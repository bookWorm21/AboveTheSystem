using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheetResourceAdder : MonoBehaviour
{
    [SerializeField] private Purse _purse;

    [Space(order = 15)]
    [SerializeField] private Resources _ore;
    [Space(order = 15)]
    [SerializeField] private Resources _wood;
    [Space(order = 15)] 
    [SerializeField] private Resources _crystal;
    [Space(order = 15)] 
    [SerializeField] private Resources _food;

#if UNITY_EDITOR
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            _purse.AddResources(_ore);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            _purse.AddResources(_wood);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            _purse.AddResources(_crystal);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            _purse.AddResources(_food);
        }
    }
#endif
}
