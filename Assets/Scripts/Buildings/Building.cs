using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private GameObject _house;
    [SerializeField] private BuildingGhost _ghost;
    [SerializeField] private BuildingProfile _profile;
    [SerializeField] private BuildingInfoForView _infoForView;
    [SerializeField] private Vector2Int _size;

    [SerializeField] private bool _isPlace = false;

    public BuildingGhost Ghost => _ghost;

    public BuildingProfile Profile => _profile;

    private void OnEnable()
    {
        _ghost.Placed += OnPlaced;
    }

    private void Start()
    {
        if(_isPlace)
        {
            _house.SetActive(true);
            _ghost.Place();
            _infoForView.Place();
        }
        else
        {
            _house.SetActive(false);
        }
    }

    private void OnPlaced()
    {
        _house.SetActive(true);
        _isPlace = true;
    }

    #region DrawGizmoz
    private void OnDrawGizmos()
    {
        for (int x = 0; x < _size.x; x++)
        {
            for (int y = 0; y < _size.y; y++)
            {
                if ((x + y) % 2 == 0)
                {
                    Gizmos.color = new Color(0.88f, 0f, 1f, 0.3f);
                }
                else
                {
                    Gizmos.color = new Color(1f, 0.68f, 0f, 0.3f);
                }

                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, .1f, 1));
            }
        }
    }
    #endregion
}
