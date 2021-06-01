using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MiniGameDirctor : MonoBehaviour
{
    private float nextTime = 0.0f;
    // Start is called before the first frame update
    private float TimeLeft  =1.0f;
    private int iter = 0;
    // Start is called before the first frame update
    public int succ_or_fail;
    public int score = 0;

    public int heart = 4;

    public Text Score_text;
    public Text heart_text;
    private int GameEndFlag;
    void Start()
    {
        succ_or_fail = PlayerPrefs.GetInt("succ_or_fail" , 1);
        score = PlayerPrefs.GetInt("score" , 0);
        heart = PlayerPrefs.GetInt("heart" , 4);
        //GameEndFlag = PlayerPrefs.GetInt("GameEndFlag" , 0);
        score++;
        if(succ_or_fail == 0)
        {
            //PlayerPrefs.SetInt("succ_or_fail" , 0);
            PlayerPrefs.SetInt("heart" , --heart);
            if(heart == 0)
            {
                //PlayerPrefs.SetInt("GamEndFlag" , 1);
                GameEndFlag = 1;
            }
        }
        PlayerPrefs.SetInt("score" , score);
        Score_text.text = "점수 :" + score;
        heart_text.text = "체력 :" +heart;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameEndFlag == 0)
        {
        if (iter == 5)
        {
            //랜덤넘버로 4개의 씬을 로드 같은거 허용
            //라이프 playerprefs로 4개로 갖고 온 뒤 이전버튼으로 돌아가면 셋인트로 초기화 라이프에 따라서 다른 스프라이트 로딩
            //7개 프레임으로 구성 or 애니메이션 배경화면
            int rand = Random.Range(1,5);
            if(rand == 1)
            {
            SceneManager.LoadScene("MiniGameSub_01");
            }
            else if(rand == 2)
            {
            SceneManager.LoadScene("MiniGameSub_02");
            }
            else if(rand == 3)
            {
            SceneManager.LoadScene("MiniGameSub_03");
            }
            else if(rand == 4)
            {
            SceneManager.LoadScene("MiniGameSub_04");
            }
        }
        else if(Time.time>nextTime)
        {
            nextTime = Time.time + TimeLeft;
            iter++;
        }
        }
        else{
            heart_text.text = "수고하셨습니다.";
        }
        if(Application.platform == RuntimePlatform.Android)
        {
  
            if(Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("GameStartScene");
            }


        }
        

    }
}
