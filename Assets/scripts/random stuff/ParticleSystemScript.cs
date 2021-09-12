using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemScript : MonoBehaviour
{
    Transform target;
    void Start()
    {
        target = transform.parent;
    }

    void Update()
    {
        //particleSystem.start
    }
}
