using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCamera : MonoBehaviour
{
    private Camera C;
    float size = 12.5f;
    public float modifier = 300f;
    void Start()
    {
        C = FindObjectOfType<Camera>();
    }
    float a;
    
    void FixedUpdate()
    {
        a = Input.GetAxis("Mouse ScrollWheel");

        a *= -1;

        size += a * modifier;
        if (size > 20f)
        {
            size = 20f;
        }
        if (size < 5f)
        {
            size = 5f;
        }
        C.orthographicSize = size;

        
    }
}
