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
    public static bool succ_or_fail;
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
            SceneManager.LoadScene("MiniGameSub_01");
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
