using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItemProperty : ItemProperty
{
    public int count;

    public InventoryItemProperty(string name, Sprite sprite, string explain, int cost, int index, int count)
    {
        this.name = name;
        this.sprite = sprite;
        this.explain = explain;
        this.cost = cost;
        this.index = index;
        this.count = count;
    }
}
