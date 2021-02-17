﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDestructibility : MonoBehaviour
{
    private Building _building;

    private float _lives;
    private float _maxLives;

    public event System.Action<float> LivesChanged;

    private void Start()
    {
        _building = GetComponent<Building>();
        _maxLives = _building.Profile.Health;
    }

    public void ApplyDamage(float damage)
    {
        _lives -= damage;
        if (_lives > 0)
        {
            LivesChanged?.Invoke(_lives / _maxLives);
        }
        else
        {
            // destroy
        }
    }
}
