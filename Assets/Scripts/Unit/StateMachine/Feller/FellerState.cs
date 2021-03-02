﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellerState : State
{
    [SerializeField] protected Feller _feller;

    protected int _miningHash = Animator.StringToHash("mining");
    protected int _walkingHash = Animator.StringToHash("move");
}
