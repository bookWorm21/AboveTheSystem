using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaft : ResourceSource
{
    protected override void Destroy()
    {
        throw new System.Exception("shaft object can not destroy");
    }
}
