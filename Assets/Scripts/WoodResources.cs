using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodResources : MonoBehaviour
{
    [SerializeField] private PlaceLogic _placeLogic;

    private List<SawmillInfo> _sawmills = new List<SawmillInfo>();
    private List<Feller> _waitingUnits = new List<Feller>();
    private Tree[] _trees;
    private int _indexFromStartDestroyedTrees;

    private bool _haveWaitingUnits;

    private static WoodResources _instance;

    public static WoodResources Instance => _instance;

    private void OnEnable()
    {
        _placeLogic.SmashedBuilding += OnPlaceNewBuilding;
    }

    private void Start()
    {
        if(_instance != null)
        {
            Destroy(this);
        }

        _instance = this;

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
        //TODO:сделать поиск ближайшего источника, аналогично деревьям
        int buildIndex = -1;
        float minDistance = float.MaxValue;

        if (_haveWaitingUnits == false)
        {
            for (int i = 0; i < _sawmills.Count; i++)
            {
                if (_sawmills[i] != null)
                {
                    float currentDistance = Vector3.Distance(position, _sawmills[i].transform.position);
                    if (currentDistance < minDistance)
                    {
                        minDistance = currentDistance;
                        buildIndex = i;
                    }
                }
            }

            if (buildIndex == -1)
            {
                _sawmills = new List<SawmillInfo>();
                return null;
            }
            else
            {
                return _sawmills[buildIndex].GetComponent<BuildingResourceContainer>();
            }
        }
        else
        {
            return null;
        }
    }

    public void AddInWaitingList(Feller feller)
    {
        _haveWaitingUnits = true;
        _waitingUnits.Add(feller);
    }

    public Tree GetNearTree(Vector3 unitPosition)
    {
        if(_indexFromStartDestroyedTrees <= 0)
        {
            return null;
        }

        Tree target = null;
        int treeIndex = 0;
        float minDistance = float.MaxValue;

        while (target == null && _indexFromStartDestroyedTrees > 0)
        {
            for (int i = 0; i < _indexFromStartDestroyedTrees; i++)
            {
                if (_trees[i] != null && _trees[i].IsDestroy == false)
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

                    _trees[i] = _trees[_indexFromStartDestroyedTrees - 1];
                    _trees[_indexFromStartDestroyedTrees - 1] = template;

                    _indexFromStartDestroyedTrees--;
                }
            }

            target = _trees[treeIndex];
        }

        return target;
    }


    private void OnPlaceNewBuilding(Building building)
    {
        if(building.TryGetComponent(out SawmillInfo sawmill))
        {
            _sawmills.Add(sawmill);
            
            if(_haveWaitingUnits)
            {
                for(int i = 0; i < _waitingUnits.Count; i++)
                {
                    _waitingUnits[i].PlaceSource(sawmill);
                }

                _waitingUnits = new List<Feller>();
                _haveWaitingUnits = false;
            }
        }
    }
}
