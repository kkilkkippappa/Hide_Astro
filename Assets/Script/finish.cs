using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject popup;    // 팝업창 오브젝트
    void Start()
    {
        //popup = GameObject.FindWithTag("popup");
        //popup.SetActive(false); // 팝업 비활성화
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        // Player 태그 붙인 물체와 통과하면 팝업창이 생기게 한다.
        if (other.gameObject.CompareTag("player"))
        {
            //Debug.LogError("물체 충돌 감지");
            //popup.SetActive(true); // 팝업 비활성화

            // hard라면 메인화면으로 돌아가기
            if(SceneManager.GetActiveScene().name == "easyScene")
            {
                SceneManager.LoadScene("normalScene");
            }
            if (SceneManager.GetActiveScene().name == "normalScene")
            {
                SceneManager.LoadScene("hardScene");
            }
            if(SceneManager.GetActiveScene().name == "hardScene")
            {
                SceneManager.LoadScene("mainScene");
            }
        }
    }
}
