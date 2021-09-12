using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStars : MonoBehaviour
{
    StarsGeneration S;
    int sterge;
    private GameObject player;
    void Start()
    {
        S = FindObjectOfType<StarsGeneration>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        sterge = 1;
        float a;
        float b;
        a = player.transform.position.x - gameObject.transform.position.x;
        b = player.transform.position.y - gameObject.transform.position.y;
        if (Mathf.Sqrt(a * a + b * b) < S.range)
        {
            sterge = 0;
        }
        if (sterge == 1)
        {
            //print("sters");
            S.Deleted(a, b) ;
            Destroy(gameObject);
        }
    }
}
