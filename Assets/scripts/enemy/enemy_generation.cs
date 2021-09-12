using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_generation : MonoBehaviour
{
    public GameObject enemy;
    public float enemy_wait_time;
    int genereaza = 1;
    float x, y;
    void Start()
    {
        
    }

    void gen()
    {
        x = Random.Range(-12, 12);
        y = Random.Range(-12, 12);
        Vector2 poz = new Vector2(x+transform.position.x, y + transform.position.y);
        Instantiate(enemy, poz, transform.rotation);
        genereaza = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (genereaza == 1)
        {

            //gen();
            //StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(enemy_wait_time);
        genereaza = 1;
    }

}
