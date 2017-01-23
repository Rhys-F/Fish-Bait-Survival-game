using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returntostart : MonoBehaviour
{

    void Update()
    {
    }
    void OnMouseDown()
    {
        //Debug.Log("aa");
        Application.LoadLevel("click");
    }
}
