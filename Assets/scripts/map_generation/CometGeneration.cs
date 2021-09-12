using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometGeneration : MonoBehaviour
{
    public GameObject[] BackgroundObjects;
    public int standard;
    public float chance;
    int ObjectRandom;

    Vector3 poz;

    void Start()
    {
        for (int i = 1; i <= standard; i++)
        {
            ObjectRandom = Random.Range(0, BackgroundObjects.Length);

            float x = Random.Range(-15, 15);
            float y = Random.Range(-15, 15);
            float ch = Random.Range(0, 100);


            if (ch < chance)
            {
                poz = gameObject.transform.position;
                poz += new Vector3(x, y, 100f);
                //print(ObjectRandom);
                GameObject P = Instantiate(BackgroundObjects[ObjectRandom], poz, Quaternion.Euler(0f, 0f, 0f));

            }

        }
    }
}
