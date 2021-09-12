using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mutation_manager : MonoBehaviour
{
    int scor=0;
    int scor_aux=0;
    int mutation = 0;
    score_manager S;

    public GameObject Water;
    public GameObject Earth;
    public GameObject Air;
    public GameObject Fire;
    void Start()
    {
        S = GameObject.FindObjectOfType<score_manager>();
        mutation = Random.Range(1, 5);
    }


    public void GetWater(ref GameObject K)
    {
        K = Water;
        //print(K == null);
    }
    public void GetFire(ref GameObject K)
    {
        K = Fire;
        //print(K == null);
    }
    public void GetAir(ref GameObject K)
    {
        K = Air;
        //print(K == null);
    }
    public void GetEarth(ref GameObject K)
    {
        K = Earth;
       //print(K == null);
    }


    public void show_mutation(ref int a)
    {
        a = mutation;
    }
    public void Randomize(ref int mutate)
    {
        //mutation chance
        mutate = Random.Range(0, 1)+1;
        if (scor_aux<100)
        {
            mutate = 0;
        }
    }

    void Get_score()
    {
        S.Get_score(ref scor_aux);
        if (scor / 100 != scor_aux / 100)
        {
            mutation = Random.Range(1, 5);
            print(mutation);
            scor = scor_aux;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        Get_score();
    }
}


















