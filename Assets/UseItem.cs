using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public Transform SelectedItem;
    public Transform ItemRoot;

    private int count;
    private int temp;
    public void OnClickUse()
    {
        var selecteditem = SelectedItem.GetComponent<ItemIndex>();
        var item = ItemRoot.GetChild(selecteditem.index).GetComponent<Item>();
        temp = PlayerPrefs.GetInt(item.name, 0);

        if (temp > 0)
        {
            temp -= 1;
            item.icount.text = temp.ToString();
            PlayerPrefs.SetInt(item.name , temp);
        }
        else
        {
            temp += 5;
            item.icount.text = temp.ToString();
            PlayerPrefs.SetInt(item.name, temp);
        }

    }
}
