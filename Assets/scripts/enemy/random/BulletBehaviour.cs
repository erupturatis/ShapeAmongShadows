using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float AngleModif=0f;

    public float[] bulletTimes;
    public int[] bulletDirections;
    public float[] bulletSpeeds;

    public GameObject RotSus;
    public GameObject RotJos;


    int itr=0;

    public void ModifyAngle(float a)
    {
        transform.rotation = Quaternion.AngleAxis(a - 90f , Vector3.forward);
    }
    void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Vector3 dir = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (bulletTimes.Length > 0)
        {
            StartCoroutine(Wait());
        }
        StartCoroutine(Destroy());
        //print(AngleModif);
        //transform.rotation = Quaternion.AngleAxis(angle-90f + AngleModif, Vector3.forward);
    }

    void Rotate()
    {
        //print(bulletTimes.Length);
        if (itr < bulletTimes.Length && bulletDirections[itr] != 0)
        {
           
            Vector3 dir;
            if (bulletDirections[itr] == 1)
            {
                dir = RotSus.transform.position - transform.position;
            }
            else
            {
                //print("in jos");
                dir = RotJos.transform.position - transform.position;
            }
            
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), bulletSpeeds[itr]* Time.deltaTime);

        }
    }
    void Update()
    {
        transform.Translate(Vector2.up * 10f * Time.deltaTime);
        Rotate();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(bulletTimes[itr]);
        itr++;

        if (itr < bulletTimes.Length)
        {
            StartCoroutine(Wait());
        }
      
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}
