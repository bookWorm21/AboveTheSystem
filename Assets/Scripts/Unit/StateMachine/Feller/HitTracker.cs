using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTracker : MonoBehaviour
{
    public event System.Action Hitted;

    //используется анимацией
    public void HitTree()
    {
        Hitted?.Invoke();
    }
}
