using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour, IInputForCamera
{
    [SerializeField] private float _minValue;
    [SerializeField] private float _reductionFactor;

    private Vector3 _deltaPosition;
    private float _extensionValue;
    private float _lastDistanceBetweenTouches = 0;
    private float _distanceBetweenTouches = 0;

    private void LateUpdate()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                _deltaPosition = touch.deltaPosition;
            }
            else
            {
                _deltaPosition = Vector3.zero;
            }

            _extensionValue = 0;
        }
        else if(Input.touchCount == 2)
        {
            Touch first = Input.GetTouch(0);
            Touch second = Input.GetTouch(1);

            _lastDistanceBetweenTouches = _distanceBetweenTouches;
            _distanceBetweenTouches = Vector2.Distance(first.position, second.position);

            if (first.phase == TouchPhase.Moved && second.phase == TouchPhase.Moved)
            {
                _extensionValue = _distanceBetweenTouches - _lastDistanceBetweenTouches;
            }
            else
            {
                _extensionValue = 0;
            }
        }
        else
        {
            _extensionValue = 0;
        }
    }

    public Vector3 GetDeltaPosition()
    {
        Vector3 returnedVector3 = _deltaPosition;
        returnedVector3.z = returnedVector3.y;
        returnedVector3.y = 0;
        if (returnedVector3.magnitude > _minValue)
        {
            return returnedVector3 / _reductionFactor; 
        }
        else
        {
            return Vector3.zero;
        }
    }

    public float GetExtensionValue()
    {
        return _extensionValue / 200f;
    }
}
