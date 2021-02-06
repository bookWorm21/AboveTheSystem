using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcInput : MonoBehaviour, IInputForCamera
{
    private Vector3 _deltaPosition;
    private float _extensionValue;

    private Vector3 _lastPosition;

    private void LateUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _lastPosition = Input.mousePosition;
        }

        if(Input.GetMouseButton(0))
        {
            _deltaPosition = Input.mousePosition - _lastPosition;
            _lastPosition = Input.mousePosition;
        }
        else
        {
            _deltaPosition = Vector3.zero;
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
        return _extensionValue = Input.GetAxis("Mouse ScrollWheel");
    }
}
