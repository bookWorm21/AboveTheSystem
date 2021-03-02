using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] private UnitStateMachine _stateMachine;

    private void Start()
    {
        OnStart();
    }

    protected virtual void OnStart()
    {

    }
}
