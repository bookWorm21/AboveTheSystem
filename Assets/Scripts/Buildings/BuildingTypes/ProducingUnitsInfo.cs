using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProducingUnitsInfo : BuildingInfoForView
{
    private BuildingProduction _production;

    public void Produce(UnitButtonView unitButton)
    {
        if (_select)
        {
            StartCoroutine(RechargeUnitProduction(unitButton));
        }
    }

    protected override void OnStart()
    {
        _production = GetComponent<BuildingProduction>();
    }

    private IEnumerator RechargeUnitProduction(UnitButtonView unitButton)
    {
        WaitForEndOfFrame frameTime = new WaitForEndOfFrame();
        float rechargeTime = unitButton.Profile.ProductionTime;
        float elapsedTime = 0;

        while (elapsedTime < rechargeTime)
        {
            elapsedTime += Time.deltaTime;

            if (_select)
            {
                unitButton.SetProgress(elapsedTime / rechargeTime);
            }

            yield return frameTime;
        }

        if (_production != null)
        {
            _production.ProduceUnit(unitButton.Profile);
        }
    }
}
