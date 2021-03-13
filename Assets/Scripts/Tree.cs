using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : ResourceSource
{
    protected override void Destroy()
    {
        IsDestroy = true;
        InvokeDestroedEvent();

        Destroy(gameObject);
    }
}
