using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGhost : MonoBehaviour
{
    [SerializeField] private Material _collisiedMaterial;
    [SerializeField] private Material _rightPlaced;
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] private GameObject _ghost;
    [SerializeField] private Collider _collider;

    public bool IsCollisied { get; private set; }

    public event System.Action Placed;

    private void Start()
    {
        _collider.isTrigger = true;
        IsCollisied = false;
        _mesh.material = _rightPlaced;
    }

    public void Place()
    {
        Placed?.Invoke();
        _collider.isTrigger = false;
        Destroy(_ghost);
        Destroy(this);
    }

    private void OnTriggerStay()
    {
        IsCollisied = true;
        _mesh.material = _collisiedMaterial;
    }

    private void OnTriggerExit()
    {
        IsCollisied = false;
        _mesh.material = _rightPlaced;
    }
}
