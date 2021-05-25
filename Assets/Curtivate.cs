using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Curtivate : MonoBehaviour
{
    public Slider slider;
    public StatusBuffer buffer;
    public GameObject manbo_egg;
    public SpriteRenderer renderer;
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;

    public void OnClickEXPPlus()
    {
        if (buffer.status[0].exp < 100)
        {
            buffer.status[0].exp++;
            slider.value = buffer.status[0].exp;
        }
    }

    public void OnClickEXPMinus()
    {
        if (buffer.status[0].exp > 0)
        {
            buffer.status[0].exp--;
            slider.value = buffer.status[0].exp;
        }
    }

    public void OnClickEvol()
    {
        if (buffer.status[0].exp == 100)
        {
            renderer = manbo_egg.GetComponent<SpriteRenderer>();
            if (renderer.sprite == image1)
                renderer.sprite = image2;
            else if (renderer.sprite == image2)
                renderer.sprite = image3;
            buffer.status[0].exp = 0;
            slider.value = 0;
        }
    }
}
