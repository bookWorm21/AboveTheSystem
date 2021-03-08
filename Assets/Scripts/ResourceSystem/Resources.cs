using System;
using UnityEngine;

[Serializable]
public class Resources
{
    [SerializeField] private int _ore;
    [SerializeField] private int _wood;
    [SerializeField] private int _food;
    [SerializeField] private int _crystal;

    private int[] _allResources;

    public int Ore => _ore;

    public int Wood => _wood;

    public int Food => _food;

    public int Crystal => _crystal;

    private Resources(int ore, int wood, int food, int crystal)
    {
        _ore = ore;
        _wood = wood;
        _food = food;
        _crystal = crystal;

        _allResources = new int[]
        {
            _ore,
            _wood,
            _food,
            _crystal
        };
    }

    public string InputString()
    {
        return "ore - " + _ore + ", wood - " + _wood + ", food - " + _food + ", crystal - " + _crystal;
    }

    public static Resources GetEmpty()
    {
        return new Resources(0, 0, 0, 0);
    }

    public static Resources operator +(Resources first, Resources second)
    {
        return new Resources(first.Ore + second.Ore,
                             first.Wood + second.Wood,
                             first.Food + second.Food,
                             first.Crystal + second.Crystal);
    }

    public static Resources operator -(Resources first, Resources second)
    {
        return new Resources(first.Ore - second.Ore,
                             first.Wood - second.Wood,
                             first.Food - second.Food,
                             first.Crystal - second.Crystal);
    }

    public static Resources operator *(Resources resources, float value)
    {
        return new Resources(Mathf.RoundToInt(resources.Ore * value),
                             Mathf.RoundToInt(resources.Wood * value),
                             Mathf.RoundToInt(resources.Food * value),
                             Mathf.RoundToInt(resources.Crystal * value));
    }

    public static Resources operator *(float value, Resources resources)
    {
        return resources * value;
    }

    public static bool operator >(Resources first, Resources second)
    {
        if (first.Ore <= second.Ore)
            return false;
        if (first.Wood <= second.Wood)
            return false;
        if (first.Food <= second.Food)
            return false;
        if (first.Crystal <= second.Crystal)
            return false;

        return true;
    }

    public static bool operator <(Resources first, Resources second)
    {
        if (first.Ore >= second.Ore)
            return false;
        if (first.Wood >= second.Wood)
            return false;
        if (first.Food >= second.Food)
            return false;
        if (first.Crystal >= second.Crystal)
            return false;

        return true;
    }

    public static bool operator ==(Resources first, Resources second)
    {
        if (first.Ore != second.Ore)
            return false;
        if (first.Wood != second.Wood)
            return false;
        if (first.Food != second.Food)
            return false;
        if (first.Crystal != second.Crystal)
            return false;

        return true;
    }

    public static bool operator !=(Resources first, Resources second)
    {
        if (first == second)
            return false;

        return true;
    }

    public static bool operator >=(Resources first, Resources second)
    {
        if (first.Ore < second.Ore)
            return false;
        if (first.Wood < second.Wood)
            return false;
        if (first.Food < second.Food)
            return false;
        if (first.Crystal < second.Crystal)
            return false;

        return true;
    }

    public static bool operator <=(Resources first, Resources second)
    {
        if (first.Ore > second.Ore)
            return false;
        if (first.Wood > second.Wood)
            return false;
        if (first.Food > second.Food)
            return false;
        if (first.Crystal > second.Crystal)
            return false;

        return true;
    }
}
