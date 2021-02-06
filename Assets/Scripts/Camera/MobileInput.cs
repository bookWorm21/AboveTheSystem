using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour, IInputForCamera
{
    private Vector3 _deltaPosition;
    private float _extensionValue;
    private float _lastDistanceBetweenTouches = 0;
    private float _distanceBetweenTouches = 0;

    private void LateUpdate()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            _deltaPosition = touch.deltaPosition;
        }
        else if(Input.touchCount == 2)
        {
            Touch first = Input.GetTouch(0);
            Touch second = Input.GetTouch(1);
            if(first.phase == TouchPhase.Moved && second.phase == TouchPhase.Moved)
            {
                _lastDistanceBetweenTouches = _distanceBetweenTouches;
                _distanceBetweenTouches = Vector2.Distance(first.position, second.position);
                _extensionValue = _distanceBetweenTouches - _lastDistanceBetweenTouches;
            }
        }
    }

    public Vector3 GetDeltaPosition()
    {
        Vector3 returnedVector3 = _deltaPosition;
        returnedVector3.z = returnedVector3.y;
        returnedVector3.y = 0;
        return returnedVector3;
    }

    public float GetExtensionValue()
    {
        return _extensionValue;
    }
}
