using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailScript : MonoBehaviour
{
    int p = 1;

    public GameObject[] verifiere;
    
    public void IsFine(ref int r)
    {
        int lengt = verifiere.Length;
        for(int i = 0; i < lengt; i++)
        {
            IsOnTop I = verifiere[i].GetComponent<IsOnTop>();
            if (I.IsFine()==0)
            {
                p = 0;
            }
        }

        r = p;
        if (p == 1)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -0.1f);
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
