using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Curtivate : MonoBehaviour
{
    public GameObject manbo_egg;
    public GameObject manbo_background;
    public SpriteRenderer renderer;
    public Animator anim;
    public SpriteRenderer back_renderer;
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;
    public Transform status;

    private int species;
    private string shape;
    private float exp;
    private string[] statusName = new string[3] { "hunger", "feeling", "exp" };
    private Slider slider;
    public void OnClickEXPPlus()
    {
        exp = PlayerPrefs.GetFloat("exp", 0);
        if (exp < 100)
        {
            exp += 1;
            slider.value = exp;
            PlayerPrefs.SetFloat("exp", exp);
        }
    }

    public void OnClickEXPMinus()
    {
        exp = PlayerPrefs.GetFloat("exp", 0);
        if (exp > 0)
        {
            exp -= 1;
            slider.value = exp;
            PlayerPrefs.SetFloat("exp", exp);
        }
    }

    public void OnClickEvol()
    {
        exp = PlayerPrefs.GetFloat("exp", 0);
        slider = status.GetChild(2).GetComponent<Slider>();
        if (exp >= slider.maxValue)
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

                slider.maxValue = 3000;
            }
            else if(shape.Contains("kid"))
            {
                anim.enabled= false;
                shape = "ManBoGochi_creature_mid_0" + PlayerPrefs.GetString("species", "-1");
                renderer.sprite = Resources.Load<Sprite>("Graphic/Character/" + shape);
                back_renderer.sprite = Resources.Load<Sprite>("Graphic/BackGround/MANBO_BACKGROUND_04");
                
                PlayerPrefs.SetString("shape", shape);

                slider.maxValue = 5000;
            }
            else if (shape.Contains("mid"))
            {
                shape = "ManBoGochi_egg_01";
                renderer.sprite = Resources.Load<Sprite>("Graphic/Character/" + shape);

                slider.maxValue = 1000;
                SceneManager.LoadScene("EndingScene");
            }
            PlayerPrefs.SetFloat("hunger", 0);
            PlayerPrefs.SetFloat("feeling", 0);
            PlayerPrefs.SetFloat("exp", 0);
            PlayerPrefs.SetFloat("maxexp", slider.maxValue);

            for (int i = 0; i < status.childCount; i++)
            {
                slider = status.GetChild(i).GetComponent<Slider>();
                slider.value = PlayerPrefs.GetFloat(statusName[i], 0);
            }
        }
    }
}
