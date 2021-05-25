using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    public Transform SelectedItem;
    public Transform ItemRoot;
    public InventoryItemBuffer itembuffer;

    private int count;
    private int temp;
    public void OnClickBuy()
    {
            var selecteditem = SelectedItem.GetComponent<ItemIndex>();
            var item = ItemRoot.GetChild(selecteditem.index).GetComponent<Item>();
            temp = PlayerPrefs.GetInt(selecteditem.index.ToString());
            temp = temp++;
            PlayerPrefs.SetInt(selecteditem.index.ToString() , temp);
            //itembuffer.items[selecteditem.index].count = temp;
            //item.icount.text = itembuffer.items[selecteditem.index].count.ToString();

    }
}
