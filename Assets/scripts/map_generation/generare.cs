using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generare : MonoBehaviour
{
    int fa_plat;
    public bool st, dr, sus, jos;
    public GameObject platforma;
    public SpriteRenderer R;

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "coll")
        {
            fa_plat = 1;
            //print("coll");
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 80f);
            foreach (Collider2D nearbyOb in colliders)
            {
                if (nearbyOb.tag == "coll")
                {
                    //print("caladawd");
                }
                if (nearbyOb.tag == "platforma")
                {
      
                    if (st == true)
                    {
                        if (nearbyOb.transform.position.x < gameObject.transform.position.x&& nearbyOb.transform.position.y == gameObject.transform.position.y)
                        {
                            fa_plat = 0;
                   
                        }
                    }
                    if (dr == true)
                    {
                        if (nearbyOb.transform.position.x > gameObject.transform.position.x && nearbyOb.transform.position.y == gameObject.transform.position.y)
                        {
                            fa_plat = 0;
                       
                        }
                    }
                    if (sus == true)
                    {
                        if (nearbyOb.transform.position.y > gameObject.transform.position.y && nearbyOb.transform.position.x == gameObject.transform.position.x)
                        {
                            fa_plat = 0;
                  
                        }
                    }
                    if (jos == true)
                    {
                        if (nearbyOb.transform.position.y < gameObject.transform.position.y && nearbyOb.transform.position.x == gameObject.transform.position.x)
                        {
                            fa_plat = 0;
     
                        }
                    }
                }
            }
            Vector3 V = new Vector3(platforma.transform.position.x,platforma.transform.position.y,platforma.transform.position.z);
            if (fa_plat == 1)
            {
                float diff = R.bounds.size.x;
                if (st == true)
                {
                    Vector3 modif = new Vector3(-diff, 0f,0f);
                    Instantiate(platforma,V+modif,Quaternion.Euler(0f,0f,0f));
                }
                if (dr == true)
                {
                    Vector3 modif = new Vector3(diff, 0f, 0f);
                    Instantiate(platforma, V + modif, Quaternion.Euler(0f, 0f, 0f));
                }
                if (sus == true)
                {
                    Vector3 modif = new Vector3(0f,diff, 0f);
                    Instantiate(platforma, V + modif, Quaternion.Euler(0f, 0f, 0f));
                }
                if (jos == true)
                {
                    Vector3 modif = new Vector3(0f,-diff, 0f);
                    Instantiate(platforma, V + modif, Quaternion.Euler(0f, 0f, 0f));
                }
            }

        }

    }

}
