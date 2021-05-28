using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    public Transform SelectedItem;
    public Transform ItemRoot;          //����Ƽ �κ��丮���� �ִ� ItemList ������Ʈ�� ����Ŵ

    private int temp;
    public void OnClickBuy()
    {
        var selecteditem = SelectedItem.GetComponent<ItemIndex>();
        var item = ItemRoot.GetChild(selecteditem.index).GetComponent<Item>();       //ItemList ������Ʈ���� ���õ� �������� ��ȯ
        temp = PlayerPrefs.GetInt(item.name, 0);
        temp += 1;
        PlayerPrefs.SetInt(item.name, temp);
    }
}
