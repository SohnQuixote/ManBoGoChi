using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MiniGame02Manager : MonoBehaviour
{
    public SpriteRenderer renderer_bomb;
    private SpriteRenderer renderer_button;
    public Text GuideText;
    GameObject manbo_bomb;
    GameObject manbo_button;
    private string name;
    private float nextTime = 0.0f;
    // Start is called before the first frame update
    private float TimeLeft  =1.0f;
    private int iter = 6;
    private int pushed_button = 0;

    private int pushed = 0;
    public MiniGameDirctor mg;
    void Start()
    {
        name = "ManBogoChi_mini_bomb_5";
        this.manbo_bomb = GameObject.Find("Manbo_bomb");
        this.manbo_button = GameObject.Find("Manbo_button");
        renderer_bomb = manbo_bomb.GetComponent<SpriteRenderer>();
        renderer_button = manbo_button.GetComponent<SpriteRenderer>();
        renderer_bomb.sprite = Resources.Load<Sprite>("Graphic/MiniGame/" + name);
        pushed_button = Random.Range(8,15);
        GuideText.text =  pushed_button+"번 누르시오!!!";
        //Debug.Log("Hi");
    }

    // Update is called once per frame
    void set_bomb_sprite(int a){
        name = "ManBogoChi_mini_bomb_" + a.ToString();
        renderer_bomb.sprite = Resources.Load<Sprite>("Graphic/MiniGame/" + name);
    }
    void Update()
    {
        //그냥 playerPrefs 사용
        if (iter == 0)
        {
            if(pushed == pushed_button)
                {/*mg.set_succ_or_fail(true);*/ GuideText.text = "성공!!!";}
            else 
                {/*mg.set_succ_or_fail(false);*/ GuideText.text = "실패...";}
            SceneManager.LoadScene("MiniGameScene");
        }
        else if(Time.time>nextTime && iter >0)
        {
            nextTime = Time.time + TimeLeft;
            set_bomb_sprite(--iter);
        }
        if(Application.platform == RuntimePlatform.Android)
        {
            if(Input.GetMouseButtonDown(0))
            {
                pushed++;
                GuideText.text = pushed +"!!!";
                renderer_button.sprite =  Resources.Load<Sprite>("Graphic/MiniGame/" + "ManBogoChi_mini_button_1");
            }
            if(Input.GetMouseButtonUp(0))
            {
                renderer_button.sprite =  Resources.Load<Sprite>("Graphic/MiniGame/" + "ManBogoChi_mini_button_0");
            }
            if(Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("GameStartScene");
            }


        }
    }
}
