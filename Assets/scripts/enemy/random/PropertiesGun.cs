using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertiesGun : MonoBehaviour
{


    [System.Serializable]
    public class date
    {
        public float[] bulletTimes;
        public int[] bulletDirections;
        public float[] bulletSpeeds;

        public date(int k)
        {
            bulletTimes = new float[k];
            bulletDirections = new int[k];
            bulletSpeeds = new float[k];
        }
    }

    public date[] TrajectOfJets;
    public int NumberOfJets;

    public float RotationSpeed;

    public float CooldownBetBullets;
    public float HeatoutTime;
    public float HeatoutDuration;
    public int RotationSwitch;

    public float AngleDistanceBetJets;

    public int bulletType;


    private void SetJetsTrajectory()
    {
        TrajectOfJets = new date[NumberOfJets];

        int r = Random.Range(5, 10);

        for (int i = 0; i <= NumberOfJets-1; i++)
        {
            TrajectOfJets[i] = new date(r);
        }
        TrajectOfJets[0].bulletDirections[0] = 1;
        //print(TrajectOfJets[0].bulletDirections[0]);
        
        for (int i = 0; i <= NumberOfJets/2; i++)
        {
            for(int j = 0; j <= r - 1; j++)
            {
                
                int a = Random.Range(1,3);
                if (a == 2) { a = -1; }
                TrajectOfJets[i].bulletDirections[j] = a;
                TrajectOfJets[NumberOfJets-1-i].bulletDirections[j] = a*-1;
            }
        }
        for(int j = 0; j <= r - 1; j++)
        {
            float speed = Random.Range(50f, 100f);
            float time = Random.Range(0.3f, 0.5f);
            for(int i = 0; i <= NumberOfJets-1; i++)
            {
                TrajectOfJets[i].bulletSpeeds[j] = speed;
                TrajectOfJets[i].bulletTimes[j] = time;
            }
        }
        
    }

    public class date2
    {
        public int[] nr;
        public date2(int a)
        {
            nr = new int[2];
 
        }
    }
    private date2[] P;
    private void Start() {
        SetJetsTrajectory();
        //P = new date2[2];
        //P[0] = new date2(2);
        //P[1] = new date2(5);

        //TrajectOfJets = new date[1];
        //TrajectOfJets[0] = new date(2);
    }

    public void SetTest()
    {
        NumberOfJets = 1;

        RotationSpeed = 0;
        CooldownBetBullets = 0.5f;
        HeatoutTime = 5f;
        HeatoutDuration = 2f;
        RotationSwitch = 0;
        bulletType = 1;
    }
}

    


