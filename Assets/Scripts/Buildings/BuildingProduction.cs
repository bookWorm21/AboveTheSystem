using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingProduction : MonoBehaviour
{
    [SerializeField] private Transform _pointForSpawn;

    public event System.Action<Unit> SpawnedUnit;
    public void ProduceUnit(UnitProfile profile)
    {
        Unit unit = Instantiate(profile.Prefab, _pointForSpawn.position, _pointForSpawn.rotation);
        SpawnedUnit?.Invoke(unit);
    }
}
