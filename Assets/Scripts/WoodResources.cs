using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodResources : MonoBehaviour
{
    [SerializeField] private PlaceLogic _placeLogic;

    private List<SawmillInfo> _sawmills = new List<SawmillInfo>();
    private Tree[] _trees;
    private int _indexFromStartDestroyedTrees;

    private static WoodResources _instance;

    public static WoodResources Instance => _instance;

    private void OnEnable()
    {
        _placeLogic.SmashedBuilding += OnPlaceNewBuilding;
    }

    private void Start()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }

        _trees = FindObjectsOfType<Tree>();
        SawmillInfo[] sawmills = FindObjectsOfType<SawmillInfo>();

        for(int i = 0; i < sawmills.Length; i++)
        {
            _sawmills.Add(sawmills[i]);
        }

        _indexFromStartDestroyedTrees = _trees.Length;
    }

    private void OnDisable()
    {
        _placeLogic.SmashedBuilding -= OnPlaceNewBuilding;
    }

    public BuildingResourceContainer GetNearSource(Vector3 position)
    {
        return _sawmills[0].GetComponent<BuildingResourceContainer>();
    }

    public Tree GetNearTree(Vector3 unitPosition)
    {
        if(_indexFromStartDestroyedTrees <= 0)
        {
            return null;
        }

        int treeIndex = 0;
        float minDistance = Vector3.Distance(unitPosition, _trees[0].transform.position);

        for(int i = 0; i < _indexFromStartDestroyedTrees; i++)
        {
            if(_trees[i].IsDestroy == false)
            {
                float currentDistance = Vector3.Distance(unitPosition, _trees[i].transform.position);
                if (currentDistance < minDistance)
                {
                    treeIndex = i;
                    minDistance = currentDistance;
                }
            }
            else
            {
                Tree template = _trees[i];
                if(_indexFromStartDestroyedTrees < _trees.Length)
                {
                    _trees[_indexFromStartDestroyedTrees - 1] = _trees[i];
                }
                else
                {
                    _trees[i] = _trees[_indexFromStartDestroyedTrees - 1];
                    _trees[_indexFromStartDestroyedTrees - 1] = template;
                }

                _indexFromStartDestroyedTrees--;
            }
        }

        return _trees[treeIndex];
    }

    private void OnPlaceNewBuilding(Building building)
    {
        if(building.TryGetComponent(out SawmillInfo sawmill))
        {
            _sawmills.Add(sawmill);
        }
    }
}
