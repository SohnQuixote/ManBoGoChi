using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryItemBuffer itemBuffer;
    public Transform ItemRoot;

    private List<Item> itemList;

    // Start is called before the first frame update
    void Start()
    {
        itemList = new List<Item>();

        int itemCount = ItemRoot.childCount;

        itemBuffer.SetBuffer();

        for (int i = 0; i < itemCount; i++)
        {
            var item = ItemRoot.GetChild(i).GetComponent<Item>();

            if (i < itemBuffer.items.Count)
            {
                item.SetInventoryItem(itemBuffer.items[i]);
            }
            else
            {
                item.GetComponent<UnityEngine.UI.Button>().interactable = false;
            }

            itemList.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
