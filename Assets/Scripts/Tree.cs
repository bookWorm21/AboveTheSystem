using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [Header("for destroy")]
    [SerializeField] private int _health;

    public bool IsDestroy { get; private set; }

    public event System.Action Destroed;

    public int ApplyDamage(int hit)
    {
        if(hit >= _health)
        {
            Destroy();
            return _health;
        }
        else
        {
            _health -= hit;
            return hit;
        }
    }

    private void Destroy()
    {
        IsDestroy = true;
        Destroed?.Invoke();
    }
}
