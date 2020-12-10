using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 이 게임내에서 사용할 모든 버튼 함수들을 정리함.
public class onclickButton : MonoBehaviour
{
    private bool isPause = false;

    public GameObject puasePopup;   // 일시정지 누를 때 나올 팝업.
    // Start is called before the first frame update
    void Start()
    {
        puasePopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    // 팝업창에서 레벨 선택 버튼 클릭할 경우 
    public void onClick_selectScene()
    {
        SceneManager.LoadScene("selectLevelScene");
    }

    public void onClick_easy()
    {
        SceneManager.LoadScene("easyScene");
    }
    public void onClick_normal()
    {
        SceneManager.LoadScene("normalScene");
    }
    public void onClick_hard()
    {
        SceneManager.LoadScene("hardScene");
    }
    // 메인씬 이동 버튼 누를 때
    public void onClick_mainScene()
    {
        SceneManager.LoadScene("mainScene");
    }
    // 도움말 화면으로 이동할 때
    public void onClick_help()
    {
        SceneManager.LoadScene("helpScene");
    }

    // 일시정지 버튼 눌렀을 때
    public void onClick_pause()
    {
        // 일시정지 상태가 아니면 if문
        if(!isPause)
        {
            Time.timeScale = 0; // Time.timeScale은 시간 비율을 나타냄. 1은 1배속, 2는 2배속...
            //Debug.LogError("일시정지!");
            puasePopup.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            //Debug.LogError("일시정지 해제!");
            puasePopup.SetActive(false);
        }
        isPause = !isPause; // 실행한 다음 isPause 반전.
    }
    public void onClick_quit()
    {
        Application.Quit();
    }
}
