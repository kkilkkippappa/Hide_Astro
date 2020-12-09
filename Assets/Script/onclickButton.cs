using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 이 게임내에서 사용할 모든 버튼 함수들을 정리함.
public class onclickButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
    public void onClick_quit()
    {
        Application.Quit();
    }
}
