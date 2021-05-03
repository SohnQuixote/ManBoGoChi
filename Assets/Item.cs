using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemProperty iprop;
    public UnityEngine.UI.Image image;

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
        }
    }
}
