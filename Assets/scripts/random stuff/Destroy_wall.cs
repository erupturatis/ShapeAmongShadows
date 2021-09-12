using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_wall : MonoBehaviour
{
    public float time;
    public GameObject particles;
    private void Start()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(time);
        Instantiate(particles, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
