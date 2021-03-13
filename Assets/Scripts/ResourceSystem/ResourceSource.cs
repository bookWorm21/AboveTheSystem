using UnityEngine;

public abstract class ResourceSource : MonoBehaviour
{
    [Header("for destroy")]
    [SerializeField] private int _health;
    [SerializeField] private bool _destructible;

    public bool IsDestroy { get; protected set; }


    public event System.Action Destroed;

    public int ApplyDamage(int hit)
    {
        int resultHit;

        if (_destructible)
        {
            if (hit >= _health)
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
        }
        else
        {
            resultHit = hit;
        }

        return resultHit;
    }

    protected void InvokeDestroedEvent()
    {
        Destroed?.Invoke();
    }

    protected abstract void Destroy();
}
