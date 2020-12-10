using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // �ִϸ��̼� �Լ�
      private Animator anim;
      private CharacterController controller;

      public float speed = 600.0f;
      public float turnSpeed = 400.0f;
      private Vector3 moveDirection = Vector3.zero;
      public float gravity = 20.0f;

      private int max_hp = 0; // �ִ� ü��
      private int hp = 0;    // ���� ü���� ��Ÿ���ִ� hp.

      public GameObject life1, life2, life3;

    void Start()
      {
            controller = GetComponent<CharacterController>();
            anim = gameObject.GetComponentInChildren<Animator>();

            // easy, normal������ hp�� 3, hard������ hp�� 2��� �Ѵ�.
            if(SceneManager.GetActiveScene().name == "easyScene" || SceneManager.GetActiveScene().name == "normalScene")
        {
            max_hp = 3;
        }
            else if(SceneManager.GetActiveScene().name == "hardScene")
        {
            max_hp = 2;
            life3.SetActive(false); // life3�� �ʿ������ false
        }
        hp = max_hp;
        Debug.Log("���� ü�� : " + hp);
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
        // ���� ��Ʈ�� �ε����ٸ� ü�� 1 ����.
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

        // �� ���̴��� �ε����ٸ� hp ����
        /*if(other.gameObject.tag == "")
        {
            // easy, normal / hard �� �����ؼ� life image ó���ؾ���.
            if(max_hp == 3)
            {
                switch (hp)
                {
                    case 0:
                        life1.SetActive(false);
                        // �ؿ� ���ӿ��� �ۼ�.
                        break;
                    case 1:
                        life2.SetActive(false);
                        break;
                    case 2:
                        life3.SetActive(false);
                        break;
                    case 3:
                        // �ִ�����̴� �ƹ��� �ൿ ���ص� ��.
                        break;
                }
            }
            else if(max_hp == 2)
            {
                switch (hp)
                {
                    case 0:
                        life1.SetActive(false);
                        // �ؿ� ���ӿ��� �ۼ�.
                        break;
                    case 1:
                        life2.SetActive(false);
                        break;
                    case 2:
                        // �ִ�����̴� �ƹ��� �ൿ ���ص� ��.
                        break;
                }
            }
        hp--;
        }*/
        // ���� �Ծ��ٸ� 2�� ���� ���ǵ� 2��
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
        yield return new WaitForSeconds(time);  // 2�� ���� ��ٸ�.
        speed = tempSpeed;
        turnSpeed = tempTurnSpeed;
    }
}
