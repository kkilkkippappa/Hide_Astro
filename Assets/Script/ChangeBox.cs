using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBox : MonoBehaviour
{
      // Start is called before the first frame update
      public GameObject player;
      public GameObject box; 
       void Start()
      {
            player.SetActive(true);
            box.SetActive(false);
      }

      // Update is called once per frame
      void Update()
      {
            if (Input.GetKey(KeyCode.Space))
            {
                  player.SetActive(false);
                  box.SetActive(true);
                  gameObject.layer = LayerMask.NameToLayer("Map");
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                  player.SetActive(true);
                  box.SetActive(false);
                  gameObject.layer = LayerMask.NameToLayer("User");
            }
      }
}
