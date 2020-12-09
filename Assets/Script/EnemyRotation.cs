using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
      // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {
            if (Input.GetKey(KeyCode.Space))
            {
                  Debug.Log("상자 변환");
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                  Debug.Log("플레이어 돌아오기");
            }
      }
}
