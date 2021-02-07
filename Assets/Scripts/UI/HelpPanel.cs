using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panelForCancelPlacing;
    [SerializeField] private PlaceLogic _placeLogic;

    private void OnEnable()
    {
        _placeLogic.StartedPlacing += OnStartPlacing;
        _placeLogic.EndedPlacing += OnEndPlacing;
    }

    private void Start()
    {
        OnEndPlacing();
    }

    private void OnDisable()
    {
        _placeLogic.StartedPlacing -= OnStartPlacing;
        _placeLogic.EndedPlacing -= OnEndPlacing;
    }

    private void OnStartPlacing()
    {
        _panelForCancelPlacing.SetActive(true);
    }

    private void OnEndPlacing()
    {
        _panelForCancelPlacing.SetActive(false);
    }
}
