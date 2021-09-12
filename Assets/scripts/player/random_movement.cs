using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_movement : MonoBehaviour
{

    float x, y;
    float wt;
    int move=1;

    void Start()
    {
        wt = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (move == 1)
        {
            move = 0;
            x = Random.Range(-5f, 5f);
            y = Random.Range(-5f, 5f);
        }
        Vector3 mov = new Vector3(x, y, 0f);
        transform.Translate(mov * Time.deltaTime / 4);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(wt);
        move = 1;
    }

}
