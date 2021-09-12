using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOnTop : MonoBehaviour
{
    int IsOnTp=0;
    
    public int IsFine()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,new Vector3(0f,0f,1f));
        if (hit.collider.tag == "bloc")
        {
            IsOnTp = 1;
        }
        else
        {
            IsOnTp = 0;
        }


        return IsOnTp;
    }


}
