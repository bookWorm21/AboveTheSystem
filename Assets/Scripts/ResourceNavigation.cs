using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ResourceNavigation : MonoBehaviour
{
    [SerializeField] private PlaceLogic _placeLogic;

    private List<BuildingResourceContainer> _sawmills = new List<BuildingResourceContainer>();
    private List<Erner> _waitingUnits = new List<Erner>();
    private ResourceSource[] _sources;

    private int _indexFromStartDestroyedTrees;

    private bool _haveWaitingUnits;

    private void OnEnable()
    {
        _placeLogic.SmashedBuilding += OnPlaceNewBuilding;
    }

    private void Start()
    {
        _sources = FindResourceSource();
        BuildingResourceContainer[] sawmills = FindBuildingContainers();

        for(int i = 0; i < sawmills.Length; i++)
        {
            _sawmills.Add(sawmills[i]);
        }

        _indexFromStartDestroyedTrees = _sources.Length;
    }

    private void OnDisable()
    {
        _placeLogic.SmashedBuilding -= OnPlaceNewBuilding;
    }

    protected abstract BuildingResourceContainer[] FindBuildingContainers();

    protected abstract bool TryGetComponentSpecialContainer(Building building, out BuildingResourceContainer container);

    protected abstract ResourceSource[] FindResourceSource();

    public BuildingResourceContainer GetNearSalePoint(Vector3 position)
    {
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
                _sawmills = new List<BuildingResourceContainer>();
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

    public void AddInWaitingList(Erner feller)
    {
        _haveWaitingUnits = true;
        _waitingUnits.Add(feller);
    }

    public ResourceSource GetNearSource(Vector3 unitPosition)
    {
        if(_indexFromStartDestroyedTrees <= 0)
        {
            return null;
        }

        ResourceSource target = null;
        int treeIndex = 0;
        float minDistance = float.MaxValue;

        while (target == null && _indexFromStartDestroyedTrees > 0)
        {
            for (int i = 0; i < _indexFromStartDestroyedTrees; i++)
            {
                if (_sources[i] != null && _sources[i].IsDestroy == false)
                {
                    float currentDistance = Vector3.Distance(unitPosition, _sources[i].transform.position);
                    if (currentDistance < minDistance)
                    {
                        treeIndex = i;
                        minDistance = currentDistance;
                    }
                }
                else
                {
                    ResourceSource template = _sources[i];

                    _sources[i] = _sources[_indexFromStartDestroyedTrees - 1];
                    _sources[_indexFromStartDestroyedTrees - 1] = template;

                    _indexFromStartDestroyedTrees--;
                }
            }

            target = _sources[treeIndex];
        }

        return target;
    }

    private void OnPlaceNewBuilding(Building building)
    {
        if(TryGetComponentSpecialContainer(building, out BuildingResourceContainer sawmill))
        {
            _sawmills.Add(sawmill);
            
            if(_haveWaitingUnits)
            {
                for(int i = 0; i < _waitingUnits.Count; i++)
                {
                    _waitingUnits[i].PlaceSource(sawmill);
                }

                _waitingUnits = new List<Erner>();
                _haveWaitingUnits = false;
            }
        }
    }
}
