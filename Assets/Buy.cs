using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    public Transform SelectedItem;
    public Transform ItemRoot;          //유니티 인벤토리씬에 있는 ItemList 오브젝트를 가리킴

    private int temp;
    public void OnClickBuy()
    {
        var selecteditem = SelectedItem.GetComponent<ItemIndex>();
        var item = ItemRoot.GetChild(selecteditem.index).GetComponent<Item>();       //ItemList 오브젝트에서 선택된 아이템을 반환
        temp = PlayerPrefs.GetInt(item.name, 0);
        temp += 1;
        PlayerPrefs.SetInt(item.name, temp);
    }
}
