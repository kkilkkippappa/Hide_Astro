using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // 애니메이션 함수
      private Animator anim;
      private CharacterController controller;

      public float speed = 600.0f;
      public float turnSpeed = 400.0f;
      private Vector3 moveDirection = Vector3.zero;
      public float gravity = 20.0f;

      private int max_hp = 0; // 최대 체력
      private int hp = 0;    // 현재 체력을 나타내주는 hp.

      public GameObject life1, life2, life3;

    void Start()
      {
            controller = GetComponent<CharacterController>();
            anim = gameObject.GetComponentInChildren<Animator>();

            // easy, normal에서는 hp가 3, hard에서는 hp가 2어야 한다.
            if(SceneManager.GetActiveScene().name == "easyScene" || SceneManager.GetActiveScene().name == "normalScene")
        {
            max_hp = 3;
        }
            else if(SceneManager.GetActiveScene().name == "hardScene")
        {
            max_hp = 2;
            life3.SetActive(false); // life3은 필요없으니 false
        }
        hp = max_hp;
        Debug.Log("현재 체력 : " + hp);
      }

      void Update()
      {
            if (gameObject.layer == 9)
            {

                  if (Input.GetKey("w"))
                  {
                        anim.SetInteger("AnimationPar", 1);
                  }
                  else
                  {
                        anim.SetInteger("AnimationPar", 0);
                  }

                  if (controller.isGrounded)
                  {
                        moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
                  }

                  float turn = Input.GetAxis("Horizontal");
                  transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
                  controller.Move(moveDirection * Time.deltaTime);
                  moveDirection.y -= gravity * Time.deltaTime;
            }
      }

    private void OnTriggerEnter(Collider other)
    {
        // 만약 하트와 부딪혔다면 체력 1 증가.
        if(other.gameObject.tag == "heart")
        {   
            Destroy(other.gameObject);
            if (hp != max_hp)
            {
                if (max_hp == 3)
                {
                    switch (hp)
                    {
                        case 1:
                            life2.SetActive(true);
                            break;
                        case 2:
                            life3.SetActive(true);
                            break;
                    }
                }
                else if(max_hp == 2)
                {
                    switch (hp)
                    {
                        case 1:
                            life2.SetActive(true);
                            break;
                    }
                }
                hp++;
            }
        }

        // 적 레이더와 부딪혔다면 hp 감소
        /*if(other.gameObject.tag == "")
        {
            // easy, normal / hard 씬 구분해서 life image 처리해야함.
            if(max_hp == 3)
            {
                switch (hp)
                {
                    case 0:
                        life1.SetActive(false);
                        // 밑에 게임오버 작성.
                        break;
                    case 1:
                        life2.SetActive(false);
                        break;
                    case 2:
                        life3.SetActive(false);
                        break;
                    case 3:
                        // 최대생명이니 아무런 행동 안해도 됨.
                        break;
                }
            }
            else if(max_hp == 2)
            {
                switch (hp)
                {
                    case 0:
                        life1.SetActive(false);
                        // 밑에 게임오버 작성.
                        break;
                    case 1:
                        life2.SetActive(false);
                        break;
                    case 2:
                        // 최대생명이니 아무런 행동 안해도 됨.
                        break;
                }
            }
        hp--;
        }*/
        // 별을 먹었다면 2초 동안 스피드 2배
        if (other.gameObject.tag == "star")
        {
            Destroy(other.gameObject);
            StartCoroutine(eatStar(2.0f));
        }
    }
    IEnumerator eatStar(float time)
    {
        float tempSpeed = speed;
        float tempTurnSpeed = turnSpeed;
        speed *= 2;
        turnSpeed *= 2;
        yield return new WaitForSeconds(time);  // 2초 동안 기다림.
        speed = tempSpeed;
        turnSpeed = tempTurnSpeed;
    }
}
