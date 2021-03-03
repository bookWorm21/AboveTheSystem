using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingResourceContainer : MonoBehaviour
{
    public event System.Action<Resources> Mined;

    public void Pick(Resources resources)
    {
        Mined?.Invoke(resources);
    }
}
