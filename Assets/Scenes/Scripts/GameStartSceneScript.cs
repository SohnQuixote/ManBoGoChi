using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartSceneScript : MonoBehaviour
{
    
    GameObject money;
    GameObject home_menu;
    GameObject  manbo_money;
    int a=0;
    // Start is called before the first frame update
    private int click_count;
    private bool last_state;
    void Start()
    {
        Input.gyro.enabled = true;
        this.money = GameObject.Find("Money");
        this.manbo_money = GameObject.Find("ManboGochi_menu_money");
        this.home_menu = GameObject.Find("ManboGochi_menu_home_01");
        click_count =0;
        last_state = false;
        this.money.GetComponent<Text>().text = a + "원";
    }

    // Update is called once per frame
    void Update()
    {
        bool state = Input.GetMouseButton(0);
        if(state == false)
            if(last_state != state)
                    click_count++;
        last_state = state;
            
        this.money.GetComponent<Text>().text = click_count+ "원";
        if(Application.platform == RuntimePlatform.Android)
        {
            if(Input.GetKey(KeyCode.Home))
            {

            }
            else if(Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main_Scene");
            }
            else if(Input.GetKey(KeyCode.Menu))
            {

            }


        }
    }
}
