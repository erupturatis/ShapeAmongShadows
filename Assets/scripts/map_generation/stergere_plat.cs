using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stergere_plat : MonoBehaviour
{

    int sterge;
    private GameObject player;
    // Update is called once per frame
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        sterge = 1;


        float a;
        float b;
        a = player.transform.position.x - gameObject.transform.position.x;
        b = player.transform.position.y - gameObject.transform.position.y;
        if (Mathf.Sqrt(a * a + b * b) < 200)
        {
            sterge = 0;
        }
        if (sterge == 1)
        {
            //print("sters");
            Destroy(gameObject);

        }
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 10f);
        int cn = 0;
        foreach (Collider2D nearbyOb in colliders)
        {
            if (nearbyOb.tag == "platforma")
            {
                cn++;
            }
        }
        if (cn >= 2)
        {
            //print("folose");
            Destroy(gameObject);
        }
    }
}

