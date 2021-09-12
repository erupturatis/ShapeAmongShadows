using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    GameObject Camera;

    Vector3 InitPos;
    Vector3 CameraInit, CameraNow;
    Vector3 HowMuchMove;
    public float ParralexGrade;


    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        InitPos = gameObject.transform.position;
        CameraInit = Camera.transform.position;

    }

    public void SetParralax(float a)
    {
        ParralexGrade = a;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CameraNow = Camera.transform.position;
        HowMuchMove = (CameraNow - CameraInit)*ParralexGrade;
        transform.position = InitPos + HowMuchMove;
    }
}
