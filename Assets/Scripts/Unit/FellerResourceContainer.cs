using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellerResourceContainer : MonoBehaviour
{
    [Header("normalized value")]
    [SerializeField] private Resources _unitMinedResources;

    public int CurrentResourcesCount { get; private set; }

    private void Start()
    {
        CurrentResourcesCount = 0;    
    }

    public void Add(int value)
    {
        CurrentResourcesCount += value;
    }

    public Resources GetAccumulated()
    {
        int count = CurrentResourcesCount;
        CurrentResourcesCount = 0;
        return count * _unitMinedResources;
    }
}
