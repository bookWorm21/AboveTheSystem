using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingInfoForView : MonoBehaviour
{
    private BuildingDestructibility _destructibility;

    private float _lastNormalizedValue = 1;
    protected bool _select = false;

    public  bool IsInit { get; private set; }

    public SelectedTypeBuildingPanel ChosenPanel { get; private set; }

    private void Awake()
    {
        _destructibility = GetComponent<BuildingDestructibility>();
    }

    private void Start()
    {
        OnStart();
    }

    private void OnEnable()
    {
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

    protected abstract void OnStart();
}
