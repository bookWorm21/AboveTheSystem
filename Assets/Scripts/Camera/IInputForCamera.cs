using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputForCamera
{
    Vector3 GetDeltaPosition();

    float GetExtensionValue();
}
