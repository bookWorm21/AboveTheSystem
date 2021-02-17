using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Warrioe", menuName = "Unit/create warrior", order = 51)]
public class Warrior : UnitProfle
{
    [SerializeField] private float _damage;
}
