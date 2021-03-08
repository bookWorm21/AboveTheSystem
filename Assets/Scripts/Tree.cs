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
        int resultHit;
        if(hit >= _health)
        {
            Destroy();
            resultHit = _health;
            _health = 0;
        }
        else
        {
            _health -= hit;
            resultHit = hit;
        }

        return resultHit;
    }

    private void Destroy()
    {
        IsDestroy = true;
        Destroed?.Invoke();
        Destroy(gameObject);    
    }
}
