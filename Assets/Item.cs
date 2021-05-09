using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemProperty iprop;
    public UnityEngine.UI.Image image;
    public UnityEngine.UI.Image sitem;
    public UnityEngine.UI.Text iexplain;
    public UnityEngine.UI.Button Buy;

    private string cexplain;

    public void SetItem(ItemProperty iprop)
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
            cexplain = iprop.explain;
        }
    }

    public void OnClickItem()
    {
        sitem.enabled = true;
        sitem.sprite = image.sprite;

        iexplain.text = cexplain;

        Buy.interactable = true;
    }
}
