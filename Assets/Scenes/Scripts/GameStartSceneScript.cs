namespace PedometerU.Tests
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class GameStartSceneScript : MonoBehaviour
{
    public Transform status;
    SpriteRenderer renderer;
    GameObject money;
    GameObject home_menu;
    GameObject manbo_money;
    GameObject manbo_egg;
    GameObject target;
    public Text stepText;
    private Pedometer pedometer;
    //const string pluginName = "com.example.mypedometer";
    string step_text;
    
    /*void OnStep(int steps , double distance)
    {
        step_text = steps.ToString();
    }*/
    //static AndroidJavaClass _pluginClass;
    //static AndroidJavaObject _pluginInstance;
    /*public static AndroidJavaClass PluginClass{
        get{
            if(_pluginClass == null)
            {
                _pluginClass = new AndroidJavaClass(pluginName);
            }
             return _pluginClass;
        }
       
    }
    public static AndroidJavaObject PluginInstance{
        get{
            if(_pluginInstance == null)
            {
                _pluginInstance = PluginClass.CallStatic<AndroidJavaObject>("getInstance");
            }
         return _pluginInstance;
        }
         */

    //}
    int a=0;
    // Start is called before the first frame update
    private int click_count;
    private bool last_state;
    private string shape;
    private Slider slider;
    private string[] statusName = new string[3] { "hunger", "clean", "exp" };
    private int value;
    //public StepCounter counter;
    //private IntegerControl stepcount;
    void Start()
    {
        //var pedometer = new Pedometer();
        PlayerPrefs.SetInt("score" , 0);
        PlayerPrefs.SetInt("heart" , 4);
        PlayerPrefs.SetInt("GameEndFlag" ,0);
        PlayerPrefs.SetInt("succ_or_fail" , 1);
        this.money = GameObject.Find("Money");
        this.manbo_money = GameObject.Find("ManboGochi_menu_money");
        //stepcount = IntegerContorl();
        //this.home_menu = GameObject.Find("ManboGochi_menu_home_01");
        
        shape = PlayerPrefs.GetString("shape", "ManboGochi_egg_01");
        this.manbo_egg = GameObject.Find("ManboGochi_egg_01");
        renderer = manbo_egg.GetComponent<SpriteRenderer>();
        renderer.sprite = Resources.Load<Sprite>("Graphic/Character/" + shape);
        for(int i = 0; i < status.childCount; i++)
        {
            slider = status.GetChild(i).GetComponent<Slider>();
            value = PlayerPrefs.GetInt(statusName[i], 0);
            slider.value = value;
        }

        click_count =0;
        last_state = false;
        this.money.GetComponent<Text>().text = a + "원";
        pedometer = new Pedometer(OnStep);
        OnStep(0,0);
        //counter = StepCounter();
        //InputSystem.EnableDevice(counter);
        //stepcount = counter.stepCounter;
    }
    private void OnStep(int steps,double distance)
    {
        this.money.GetComponent<Text>().text = steps.ToString() + "WP";
        a =steps;
    }
    private void OnDisable() {
        pedometer.Dispose();
        pedometer = null;
    }
    void CastRay()
    {
        //target = null;
        //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //RayCastHit2D hit = Physics2D.RayCast(pos,Vector2.zero ,0f);
        //if(hit.collider != null && target == manbo_egg)
            //{
                
            //}
    }
    // Update is called once per frame
     void FixedUpdate() {
  
    }
    void Update()
    {
        //this.money.GetComponent<Text>().text = a+"WP";
        /*bool state = Input.GetMouseButton(0);
        if(state == false)
            if(last_state != state)
                    click_count++;
        last_state = state;
            
        this.money.GetComponent<Text>().text = click_count+ "원";*/
        if(Application.platform == RuntimePlatform.Android)
        {
  
            if(Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main_Scene");
            }


        }
    }
}

}

