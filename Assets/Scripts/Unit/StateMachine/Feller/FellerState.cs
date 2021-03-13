using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellerState : State
{
    [SerializeField] protected Erner _erner;

    protected int _miningHash = Animator.StringToHash("mining");
    protected int _walkingHash = Animator.StringToHash("move");
}
