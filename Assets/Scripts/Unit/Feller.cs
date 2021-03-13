using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feller : Erner
{
    protected override ResourceNavigation GetNavigation()
    {
        return WoodNavigation.GetInstance();
    }
}
