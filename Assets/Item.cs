using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemProperty iprop;
    public Transform SelectedItem;
    public UnityEngine.UI.Image image;
    public UnityEngine.UI.Image sitem;
    public UnityEngine.UI.Text iexplain;
    public UnityEngine.UI.Text icost;
    public UnityEngine.UI.Image countimage;
    public UnityEngine.UI.Text icount;
    public UnityEngine.UI.Button Buy;

    private string curexplain;
    private int curcost;
    private int curindex;

    public void SetStoreItem(ItemProperty iprop)
    {
        this.iprop = iprop;

        if(iprop == null)
        {
            image.enabled = false;

            gameObject.name = "Empty";
        }
        else
        {
            image.enabled = true;

            gameObject.name = iprop.name;
            image.sprite = iprop.sprite;
            curexplain = iprop.explain;
            curcost = iprop.cost;
            curindex = iprop.index;
        }
    }

    public void SetInventoryItem(InventoryItemProperty iprop)
    {
        this.iprop = iprop;

        if (iprop == null)
        {
            image.enabled = false;

            gameObject.name = "Empty";
        }
        else
        {
            image.enabled = true;
            icount.enabled = true;
            countimage.enabled = true;

            gameObject.name = iprop.name;
            image.sprite = iprop.sprite;
            icount.text = iprop.count.ToString();
            curexplain = iprop.explain;
            curcost = iprop.cost;
            curindex = iprop.index;
}
    }

    public void OnClickItem()
    {
        var selecteditem = SelectedItem.GetComponent<ItemIndex>();
        selecteditem.index = curindex;

        sitem.enabled = true;
        sitem.sprite = image.sprite;

        iexplain.text = curexplain;
        icost.text = curcost.ToString();

        Buy.interactable = true;
    }
}
