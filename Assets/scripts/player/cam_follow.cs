using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_follow : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        float x = player.position.x;
        float y = player.position.y;
        float z = -20f;

        transform.position = new Vector3(x, y, z);
    }
}
