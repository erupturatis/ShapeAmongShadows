using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlanet : MonoBehaviour
{
    PlanetGeneration P;
    int sterge;
    private GameObject player;
    void Start()
    {
        P = FindObjectOfType<PlanetGeneration>();
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
        if (Mathf.Sqrt(a * a + b * b) < P.range)
        {
            sterge = 0;
        }
        if (sterge == 1)
        {
            //print("sters");
            P.Deleted(a, b);
            Destroy(gameObject);
        }
    }
}
