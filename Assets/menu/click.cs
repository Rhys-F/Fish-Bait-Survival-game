using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class click : MonoBehaviour
{

    void Update()
    {
      //  if (Input.GetMouseButtonDown(0))
        //{

          //  Debug.Log("click");
            //SceneManager.LoadScene("wave 3", LoadSceneMode.Additive);
        //}
    }

    void OnMouseDown()
    {
        Application.LoadLevel("wave 1");
        //Debug.Log("click");
    }

}