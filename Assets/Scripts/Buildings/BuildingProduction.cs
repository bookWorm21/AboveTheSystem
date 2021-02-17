using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingProduction : MonoBehaviour
{
    [SerializeField] private Transform _pointForSpawn;

    public void ProduceUnit(UnitProfile profile)
    {
        Instantiate(profile.Prefab, _pointForSpawn.position, _pointForSpawn.rotation);
    }
}
