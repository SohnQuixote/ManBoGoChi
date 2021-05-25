using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public Transform SelectedItem;
    public Transform ItemRoot;
    public InventoryItemBuffer itembuffer;

    private int count;
    private int temp;
    public void OnClickUse()
    {
        var selecteditem = SelectedItem.GetComponent<ItemIndex>();
        
        if(itembuffer.items[selecteditem.index].count > 0)
        {
            var item = ItemRoot.GetChild(selecteditem.index).GetComponent<Item>();
            temp = PlayerPrefs.GetInt(selecteditem.index.ToString());
            temp = temp--;
            PlayerPrefs.SetInt(selecteditem.index.ToString() , temp);
            itembuffer.items[selecteditem.index].count = temp;
            item.icount.text = itembuffer.items[selecteditem.index].count.ToString();
        }
        else
        {

        }

    }
}
