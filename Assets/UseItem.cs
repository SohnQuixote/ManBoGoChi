using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public Transform SelectedItem;
    public Transform ItemRoot;
    public InventoryItemBuffer itembuffer;

    private int count;
    public void OnClickUse()
    {
        var selecteditem = SelectedItem.GetComponent<ItemIndex>();
        
        if(itembuffer.items[selecteditem.index].count > 0)
        {
            var item = ItemRoot.GetChild(selecteditem.index).GetComponent<Item>();

            itembuffer.items[selecteditem.index].count--;
            item.icount.text = itembuffer.items[selecteditem.index].count.ToString();
        }
        else
        {

        }

    }
}
