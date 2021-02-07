﻿using System;
using UnityEngine;

[Serializable]
public class Resources
{
    [SerializeField] private int _ore;
    [SerializeField] private int _wood;
    [SerializeField] private int _food;
    [SerializeField] private int _crystal;

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
            return true;

        return false;
    }

    public static bool operator >=(Resources first, Resources second)
    {
        if (first < second)
            return false;

        return true;
    }

    public static bool operator <=(Resources first, Resources second)
    {
        if (first > second)
            return false;

        return true;
    }
}
