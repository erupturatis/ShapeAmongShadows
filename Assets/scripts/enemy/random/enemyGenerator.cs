using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGenerator : MonoBehaviour
{
    float pix, piy;
    public int n;
    public int NrSerpuiriMin;
    public int NrSerpuiriMax;
    int[,] array;

    int NrBlocuri;

    int[] coordx = { -1, 0, 1, 0 };
    int[] coordy = { 0, 1, 0, -1 };
    public GameObject block;
    public GameObject[] TheDetails;
    float StandardSize;
    public float StandardMod;
    public int NumberDetails;

    bool Ok(int x,int y)
    {
        return (x >= 0 && y >= 0 && x < n && y < n);
    }
    void Serpuieste(int lng)
    {
        int x=n/2, y=n/2;
        int lngcurrenta = 0;
        int dir = Random.Range(0, 4);
        int Lastdir =-2;

        while (lngcurrenta <= lng)
        {
            lngcurrenta++;
            if (Ok(x, y) == false)
            {
                return;
            }
            if (array[x, y] == 0)
            {
                NrBlocuri++;
            }
            array[x,y] = 1;
            
            dir = Random.Range(0, 4);
            while (dir == Lastdir)
            {
                dir = Random.Range(0, 4);
            }
            x += coordx[dir];
            y += coordy[dir];
            if(dir == 0)
            {
                Lastdir = 2;
            }
            if (dir == 1)
            {
                Lastdir = 3;
            }
            if (dir == 2)
            {
                Lastdir = 0;
            }
            if (dir == 3)
            {
                Lastdir = 1;
            }

        }

    }

    void Make(int x,int y)
    {
        Vector3 pos;

        float dis1, dis2;
        float cx, cy;

        cx = n / 2 - x;
        cy = n / 2 - y;
        dis1 = cx * StandardSize;
        dis2 = cy * StandardSize;

        pos = new Vector3(pix + dis1, piy + dis2, 0);
        Instantiate(block, pos, Quaternion.identity);

    }

    void Construction()
    {
        int x = n / 2, y = n / 2;

        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < n; j++)
            {
                if (array[i, j] == 1)
                {
                    Make(i, j);
                }
            }
        }
    }
    
    void ConstructDetails(int MaxNumber)
    {
        int NumbDet=0;
        int m=0;
        int nr = 0;
        int PozDet=0,PozCurrent;
        int CrashPreventor=0;
        m = TheDetails.Length;


        GameObject Detail;
        while (NumbDet < MaxNumber)
        {
            nr = Random.Range(0, m);

            float rz=0f;
            rz = Random.Range(0, 360);

            float PosRandX=0, PosRandY=0;

            PozDet = Random.Range(1,NrBlocuri);
            PozCurrent = 0;

            PosRandX = 0f;
            PosRandY = 0f;

            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (array[i, j] == 1)
                    {
                        PozCurrent++;
                    }
                    if (PozDet == PozCurrent)
                    {
                        float cx, cy;

                        cx = n / 2 - i;
                        cy = n / 2 - j;
                        PosRandX = cx * StandardSize;
                        PosRandY = cy * StandardSize;
                    }
                }
            }


            

            Vector3 position = new Vector3(pix + PosRandX, piy + PosRandY, +0.1f);

            Detail = Instantiate(TheDetails[nr], position , Quaternion.Euler(0f,0f,rz));
            int t = 0;
            Detail.GetComponent<DetailScript>().IsFine(ref t);
            if (t==1)
            {
                NumbDet++;
                CrashPreventor = 0;
            }
            else
            {
                CrashPreventor++;
            }
            
            if (CrashPreventor > 100)
            {
                CrashPreventor = 0;
                NumbDet++;
                continue;
            }
        }

    }
    void Start()
    {
        pix = gameObject.transform.position.x;
        piy = gameObject.transform.position.y;
        array = new int[n,n];
        StandardSize = block.GetComponent<SpriteRenderer>().bounds.size.x*StandardMod;
        int p, r;
        p = Random.Range(NrSerpuiriMin, NrSerpuiriMax+1);
        for(int i = 1; i <= p; i++)
        {
            r = Random.Range(3, n);
            Serpuieste(r);
        }
        
        Construction();
        ConstructDetails(NumberDetails);
    }



    void Update()
    {
        
    }
}
