using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    //public CharacterController controllerplayer;
    float vertical, horizontal;
    public GameObject FlashParticles;
    public float speed;
    [SerializeField]
    private float cooldownFlash;


    public Animator An;
    Rigidbody2D rb;
    Vector2 mov;


    public void show_coord_player(ref Vector2 k)
    {
        k = transform.position;
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //print(rb);
    }

    private void RotationBehaviour()
    {

        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(angle-90, Vector3.forward),500f);


    }


    // Update is called once per frame
    void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        mov = new Vector2(horizontal * speed, vertical * speed);


        rb.MovePosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) + mov * Time.deltaTime);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            print("0");
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            print("1");
        }
        RotationBehaviour();
        //controllerplayer.Move(mov * Time.deltaTime);
        //print( gameObject. );
    }



}
