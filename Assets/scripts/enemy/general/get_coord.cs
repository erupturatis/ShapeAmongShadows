using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_coord : MonoBehaviour
{
    // Start is called before the first frame update
    public void show_coord_enemy(ref Vector2 k)
    {
        k = transform.position;
    }
}
