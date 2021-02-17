using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingProductionCooldown : MonoBehaviour
{
    private BuildingDestructibility _destructibility;

    private bool _select = false;
    private float _lastNormalizedValue = 1;

    public  bool IsInit { get; private set; }

    public SelectedTypeBuildingPanel ChosenPanel { get; private set; }

    private void Awake()
    {
        _destructibility = GetComponent<BuildingDestructibility>();
    }

    private void OnEnable()
    {
        //подписка на некое событие изменения жизней
        _destructibility.LivesChanged += OnBuildingHealthChange;
    }

    private void OnDisable()
    {
        _destructibility.LivesChanged -= OnBuildingHealthChange;
    }

    private void OnBuildingHealthChange(float normalizedValue)
    {
        _lastNormalizedValue = normalizedValue;

        if(_select)
        {
            ChosenPanel.OnBuildingHealthChange(normalizedValue);
        }
    }

    public void Place()
    {
        IsInit = true;
    }

    public void Init(SelectedTypeBuildingPanel panel)
    {
        ChosenPanel = panel;
        IsInit = true;
    }

    public void Click()
    {
        _select = true;
        ChosenPanel.OnClickAtBuilding(this);
        ChosenPanel.OnBuildingHealthChange(_lastNormalizedValue);
    }

    public void UnFocus()
    {
        _select = false;
    }

    public void Produce(UnitButtonView unitButton)
    {
        if (_select)
        {
            StartCoroutine(RechargeUnitProduction(unitButton));
        }
    }

    // Перенести метод в класс производящий юнитов
    private IEnumerator RechargeUnitProduction(UnitButtonView unitButton)
    {
        WaitForEndOfFrame frameTime = new WaitForEndOfFrame();
        float rechargeTime = unitButton.Profile.ProductionTime;
        float elapsedTime = 0;

        while (elapsedTime < rechargeTime)
        {
            elapsedTime += Time.deltaTime;

            if(_select)
            {
                unitButton.SetProgress(elapsedTime / rechargeTime);
            }

            yield return frameTime;
        }

        Debug.Log("production unit " + unitButton.Profile.name +  " ready");
    }
}
