using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Curtivate : MonoBehaviour
{
    public Slider slider;
    public GameObject manbo_egg;
    public GameObject manbo_background;
    public SpriteRenderer renderer;
    public Animator anim;
    public SpriteRenderer back_renderer;
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
            back_renderer = manbo_background.GetComponent<SpriteRenderer>();
            shape = PlayerPrefs.GetString("shape", "ManboGochi_egg_01");
            if(shape == "ManboGochi_egg_01")
            {
                anim.enabled = false;
                species = Random.Range(1, 4);
                PlayerPrefs.SetString("species", species.ToString());
                shape = "manboGochi_creature_kid_0" + species.ToString();
                renderer.sprite = Resources.Load<Sprite>("Graphic/Character/" + shape);
                back_renderer.sprite = Resources.Load<Sprite>("Graphic/BackGround/MANBO_BACKGROUND_03");
                
                PlayerPrefs.SetString("shape", shape);
            }
            else if(shape.Contains("kid"))
            {
                anim.enabled= false;
                shape = "ManBoGochi_creature_mid_0" + PlayerPrefs.GetString("species", "-1");
                renderer.sprite = Resources.Load<Sprite>("Graphic/Character/" + shape);
                back_renderer.sprite = Resources.Load<Sprite>("Graphic/BackGround/MANBO_BACKGROUND_04");
                
                PlayerPrefs.SetString("shape", shape);
            }
            else if (shape.Contains("mid"))
            {

                SceneManager.LoadScene("EndingScene");
            }
            PlayerPrefs.SetInt("exp", 0);
            slider.value = 0;
        }
    }
}
