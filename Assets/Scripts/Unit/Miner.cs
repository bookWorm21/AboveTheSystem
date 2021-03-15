using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : Erner
{
    protected override ResourceNavigation GetNavigation()
    {
        return RockNavigation.GetInstance();
    }
}
