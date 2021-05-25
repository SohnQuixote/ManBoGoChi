using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemBuffer : MonoBehaviour
{
    public List<InventoryItemProperty> items;
    public ItemBuffer itembuffer;

    private string name;
    private Sprite sprite;
    private string explain;
    private int cost;
    private int index;
    private int count;

    public void SetBuffer()
    {
        for(int i = 0; i < itembuffer.items.Count; i++)
        {
            name = itembuffer.items[i].name;
            sprite = itembuffer.items[i].sprite;
            explain = itembuffer.items[i].explain;
            cost = itembuffer.items[i].cost;
            index = itembuffer.items[i].index;
            //PlayerPrefs.SetInt(index.ToString(),0);
            count = PlayerPrefs.GetInt(index.ToString(),0);
            items.Add(new InventoryItemProperty(name, sprite, explain, cost, index, count));
        }
    }
}
