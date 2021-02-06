using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualiferPlatform : MonoBehaviour
{
    [SerializeField] private PcInput _pcInput;
    [SerializeField] private MobileInput _mobileInput;

    public IInputForCamera GetCurrentInput()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        _mobileInput.enabled = false;
        return _pcInput;
#endif
#if UNITY_ANDROID || UNITY_IOS
        _pcInput.enabled = false;
        return _mobileInput;
#endif
    }
}
