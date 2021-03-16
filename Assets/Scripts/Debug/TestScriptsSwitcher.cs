using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptsSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _debugPanel;
    [SerializeField] private bool _isTest;

    private void Awake()
    {
        if(_isTest == false)
        {
            _debugPanel.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
