using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometBH : MonoBehaviour
{
    public float speed = 20f;
    float RandomRotation;
    void Start()
    {

        RandomRotation = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f,0f,RandomRotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
