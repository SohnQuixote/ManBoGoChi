using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Curtivate : MonoBehaviour
{
    public Slider slider;
    public GameObject manbo_egg;
    public SpriteRenderer renderer;
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;

    private int species;
    private string shape;
    private int exp;

    public void OnClickEXPPlus()
    {
        exp = PlayerPrefs.GetInt("exp", 0);
        if (exp < 100)
        {
            exp += 1;
            slider.value = exp;
            PlayerPrefs.SetInt("exp", exp);
        }
    }

    public void OnClickEXPMinus()
    {
        exp = PlayerPrefs.GetInt("exp", 0);
        if (exp > 0)
        {
            exp -= 1;
            slider.value = exp;
            PlayerPrefs.SetInt("exp", exp);
        }
    }

    public void OnClickEvol()
    {
        exp = PlayerPrefs.GetInt("exp", 0);
        if (exp == 100)
        {
            renderer = manbo_egg.GetComponent<SpriteRenderer>();
            shape = PlayerPrefs.GetString("shape", "ManboGochi_egg_01");
            if(shape == "ManboGochi_egg_01")
            {
                species = Random.Range(1, 4);
                PlayerPrefs.SetString("species", species.ToString());
                shape = "manboGochi_creature_kid_0" + species.ToString();
                renderer.sprite = Resources.Load<Sprite>("Graphic/Character/" + shape);
                PlayerPrefs.SetString("shape", shape);
            }
            else if(shape.Contains("kid"))
            {
                shape = "ManBoGochi_creature_mid_0" + PlayerPrefs.GetString("species", "-1");
                renderer.sprite = Resources.Load<Sprite>("Graphic/Character/" + shape);
                PlayerPrefs.SetString("shape", shape);
            }
            PlayerPrefs.SetInt("exp", 0);
            slider.value = 0;
        }
    }
}
