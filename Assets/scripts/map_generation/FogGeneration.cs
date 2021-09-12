using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogGeneration : MonoBehaviour
{
    public GameObject Fog;
    Vector3 Position;
    void Start()
    {
        for(int i = 1; i <= 10; i++)
        {
            Position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y, i*10);
            Instantiate(Fog, Position, Quaternion.identity);

    
        }
    }

    
}
