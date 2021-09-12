using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBackground : MonoBehaviour
{
    public GameObject[] BackgroundObjects;
    public int standard;
    int FogRandomLevel=3;
    int ObjectRandom;

    Vector3 poz;

    void Start()
    {
        for(int i = 1; i <= standard; i++)
        {

            FogRandomLevel++;
            if (FogRandomLevel > 10)
            {
                FogRandomLevel = 4;
            }
            ObjectRandom = Random.Range(0, BackgroundObjects.Length );

            float x = Random.Range(-25, 25);
            float y = Random.Range(-25, 25);

            float Parallax = (FogRandomLevel) / (11f);

            poz = gameObject.transform.position;
            poz += new Vector3(x,y,3 + 10*FogRandomLevel);

            float z = Random.Range(0, 360f);
                
            GameObject P = Instantiate(BackgroundObjects[ObjectRandom],poz,Quaternion.Euler(0f,0f,z));
            SpriteRenderer R = P.GetComponent<SpriteRenderer>();
            //R.sortingLayerName = "BackElement";
            float scale;
            scale = ( 0.9f * (1-Parallax));
            Vector3 VectScale = new Vector3(scale, scale, 1f);

            P.transform.localScale = VectScale;


            Parallax Pa = P.GetComponent<Parallax>();

            Pa.SetParralax( 0.8f* Parallax );

        }
    }

 

    
}
