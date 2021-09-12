using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D projectile;
    private int can_shot=1;
    public float shoot_cdr;
    int silenced = 0;

    Vector2 enemy;
    Vector2 player;

    public int coeficient;
    int enemy_found;

    void Start()
    {
        //get chestii
        
    }

    void Find_enemy()
    {

        float minimum_distance = 40f ;
        enemy_found = 0;
        Vector2 maybe_enemy = new Vector2(0f,0f);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 40f);
        foreach (Collider2D nearbyOb in colliders)
        {
            if (nearbyOb.tag == "enemy" || nearbyOb.tag == "T1")
            {

                enemy_found = 1;
                get_coord E;
                E = nearbyOb.GetComponent<get_coord>();
                E.show_coord_enemy(ref maybe_enemy);
                if (Vector2.Distance(maybe_enemy, transform.position)<minimum_distance)
                {
                    enemy = maybe_enemy;
                    minimum_distance = Vector2.Distance(maybe_enemy, transform.position);
                }
            }
        }
    }

    public void Silecence()
    {
        silenced = 1;
        StartCoroutine(silence());
    }

    private void player_shoot()
    {
        if (can_shot == 1 && silenced ==0)
        {
            //get coord enemy
            Find_enemy();
            if (enemy_found == 1)
            {
                can_shot = 0;
                StartCoroutine(cdr_shoot());
                player = transform.position;
                Vector2 direction = (player - enemy).normalized;
                Rigidbody2D arrow = Instantiate(projectile, transform.position, Quaternion.identity) as Rigidbody2D;

                arrow.AddForce(-direction / coeficient, ForceMode2D.Impulse);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        player_shoot();
    }

    private IEnumerator cdr_shoot()
    {
        // pun timp
        yield return new WaitForSeconds(shoot_cdr);
        can_shot = 1;
    }
    private IEnumerator silence()
    {
        // pun timp
        yield return new WaitForSeconds(3f);
        silenced = 0;
    }
}
