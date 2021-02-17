using UnityEngine;

[CreateAssetMenu(fileName = "new Warrior", menuName = "Unit/create warrior", order = 51)]
public class WarriorProfile : UnitProfile
{
    [SerializeField] private float _damage;
}