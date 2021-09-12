using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGeneration : MonoBehaviour
{
    public GameObject[] BackgroundObjects;
    public int standard;
    int NumberOfObjects;
    int ObjectRandom;
    public float range;

    float sq2;

    Vector3 poz;

    public void Deleted(float a, float b)
    {
        //NumberOfObjects-=1;
        ObjectRandom = Random.Range(0, BackgroundObjects.Length);

        float x = a;
        float y = b;

        float rot = Random.Range(0, 360f);

        poz = gameObject.transform.position;
        poz += new Vector3(x * 0.95f, y * 0.95f, 50f);

        GameObject P = Instantiate(BackgroundObjects[ObjectRandom], poz, Quaternion.Euler(0f, 0f, rot));
        float rand = Random.Range(0.5f, 2f);
        Vector3 VectScale = new Vector3(rand, rand, 1f);
        P.transform.localScale = VectScale;


    }

    void Start()
    {
        sq2 = Mathf.Sqrt(2);
    }

    private void Update()
    {
        while (NumberOfObjects < standard)
        {
            ObjectRandom = Random.Range(0, BackgroundObjects.Length);

            float x = Random.Range(-range / (sq2), range / sq2);
            float y = Random.Range(-range / sq2, range / sq2);

            poz = gameObject.transform.position;
            poz += new Vector3(x, y, 100f);

            GameObject P = Instantiate(BackgroundObjects[ObjectRandom], poz, Quaternion.Euler(0f, 0f, 0f));

            float rand = Random.Range(0.7f, 1.2f);

            Vector3 VectScale = new Vector3(rand, rand, 1f);

            P.transform.localScale = VectScale;
            NumberOfObjects++;

        }
    }


}
