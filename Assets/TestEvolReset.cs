using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvolReset : MonoBehaviour
{
    public void OnResetClick()
    {
        PlayerPrefs.SetString("shape", "ManboGochi_egg_01");
    }

    public void OnEXPMaxClick()
    {
        PlayerPrefs.SetInt("exp", 100);
    }
}
