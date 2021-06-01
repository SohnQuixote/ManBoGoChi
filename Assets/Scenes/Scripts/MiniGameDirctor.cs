using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MiniGameDirctor : MonoBehaviour
{
    private float nextTime = 0.0f;
    // Start is called before the first frame update
    private float TimeLeft  =1.0f;
    private int iter = 0;
    // Start is called before the first frame update
    public bool succ_or_fail;
    public int score = 0;

    public int heart = 4;
    public void set_succ_or_fail(bool temp)
    {
        succ_or_fail = temp;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (iter == 5)
        {
            //랜덤넘버로 4개의 씬을 로드 같은거 허용
            //라이프 playerprefs로 4개로 갖고 온 뒤 이전버튼으로 돌아가면 셋인트로 초기화 라이프에 따라서 다른 스프라이트 로딩
            //7개 프레임으로 구성 or 애니메이션 배경화면
            int rand = Random.Range(1,4);
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
            SceneManager.LoadScene("MiniGameSub_03");
            }
        }
        else if(Time.time>nextTime)
        {
            nextTime = Time.time + TimeLeft;
            iter++;
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
