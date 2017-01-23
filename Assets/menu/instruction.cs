using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class instruction : MonoBehaviour
{

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
            //Debug.Log("click");
          //  SceneManager.LoadScene("realcorrectinstructionpage", LoadSceneMode.Additive);
        //}
    }

    void OnMouseDown()
    {
        //Debug.Log("click");
        Application.LoadLevel("realcorrectinstructionpage");
    }
}