using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    PropertiesGun P;
    GameObject Player;

    int ShootCond1 = 0;
    int ShootCond2 = 1;

    public Transform BulletSpawn;
    public GameObject[] Bullets;
    float angle = 0;


    

    void Start()
    {
        P = gameObject.GetComponent<PropertiesGun>();
        Player = GameObject.FindGameObjectWithTag("Player");
        
        StartCoroutine(CooldownBullet());
    }

    private void Shoot()
    {

        if(ShootCond1==1 && ShootCond2 == 1)
        {
            //Debug.Log("spawnuit");
            //print(gameObject.transform.rotation.z);
            for (int i = 1; i <= P.NumberOfJets; i++)
            {
                //print("ceva orice");
                GameObject B = Instantiate(Bullets[P.bulletType], BulletSpawn.position,Quaternion.Euler(0f,0f, 0f ));
                BulletBehaviour TP = B.GetComponent<BulletBehaviour>();

                TP.bulletTimes = P.TrajectOfJets[i - 1].bulletTimes;
                TP.bulletDirections = P.TrajectOfJets[i - 1].bulletDirections;
                TP.bulletSpeeds = P.TrajectOfJets[i - 1].bulletSpeeds;

                TP.ModifyAngle((i - P.NumberOfJets / 2 - 1) * P.AngleDistanceBetJets + transform.localEulerAngles.z);

            }
            ShootCond1 = 0;
            StartCoroutine(CooldownBullet());
        }
        
    }

    private void RotationBehaviour()
    {

        Vector3 dir = Player.transform.position - transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), P.RotationSpeed * Time.deltaTime);

        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //Quaternion.RotateTowards(transform.rotation,Quaternion.AngleAxis(angle, Vector3.forward), turningRate * Time.deltaTime);
        //print(transform.rotation);
    }

    void Update()
    {
        //RotationBehaviour();
        Shoot();
    }

    IEnumerator CooldownBullet()
    {
        yield return new WaitForSeconds(P.CooldownBetBullets );
        ShootCond1 = 1;
    }
}
