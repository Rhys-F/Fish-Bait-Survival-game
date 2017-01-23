using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    // Use this for initialization
    public float speed = 30;
    private float movex = 0f;
    private float movey = 0f;
    public float topSpeed;
    public Rigidbody2D rb;
    public float maxAccel;
    public GameObject bullet;
    public GameObject bulletR;
    public GameObject bulletU;
    public GameObject bulletD;
    public GameObject bulletUL;
    public GameObject bulletUR;
    public GameObject bulletDL;
    public GameObject bulletDR;
    public GameObject Explosion;
    public string facing = "U";

    Transform firePos;

    void Start()
    {
        firePos = transform.FindChild("firePos");
        rb = GetComponent<Rigidbody2D>();
        topSpeed = 100;
        maxAccel = 100;

    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.W))
        {
            facing = "U";
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            facing = "D";
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            facing = "L";
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            facing = "R";
        }
        if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.A))
        {
            facing = "UL";
        }
        if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.D))
        {
            facing = "UR";
        }
        if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D))
        {
            facing = "DR";
        }
        if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.A))
        {
            facing = "DL";
        }

    }

    void FixedUpdate()
    {
        var noForce = new Vector2(0, 0);
        var move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.AddForce(move * maxAccel);
        var speed = rb.velocity;
        if (speed.magnitude > topSpeed)
        {
            rb.velocity = speed * (topSpeed / rb.velocity.magnitude);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
    {
        if (facing == "U")
        {
            Instantiate(bulletU, firePos.position, Quaternion.identity);
            Instantiate(bulletD, firePos.position, Quaternion.identity);
        }
        if (facing == "D")
        {
            Instantiate(bulletU, firePos.position, Quaternion.identity);
            Instantiate(bulletD, firePos.position, Quaternion.identity);
        }
        if (facing == "L")
        {
            Instantiate(bullet, firePos.position, Quaternion.identity);
            Instantiate(bulletR, firePos.position, Quaternion.identity);
        }
        if (facing == "R")
        {
            Instantiate(bullet, firePos.position, Quaternion.identity);
            Instantiate(bulletR, firePos.position, Quaternion.identity);
        }
        if (facing == "UL")
        {
            Instantiate(bulletUL, firePos.position, Quaternion.identity);
            Instantiate(bulletDR, firePos.position, Quaternion.identity);
        }
        if (facing == "UR")
        {
            Instantiate(bulletUR, firePos.position, Quaternion.identity);
            Instantiate(bulletDL, firePos.position, Quaternion.identity);
        }
        if (facing == "DL")
        {
            Instantiate(bulletUR, firePos.position, Quaternion.identity);
            Instantiate(bulletDL, firePos.position, Quaternion.identity);
        }
        if (facing == "DR")
        {
            Instantiate(bulletUL, firePos.position, Quaternion.identity);
            Instantiate(bulletDR, firePos.position, Quaternion.identity);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyTag")
        {
            PlayExplosion();
            Destroy(gameObject);

        }
    }

    void PlayExplosion()
    {
        GameObject exp = (GameObject)Instantiate(Explosion);

        exp.transform.position = transform.position;
    }
}
