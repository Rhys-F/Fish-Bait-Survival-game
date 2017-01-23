using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{

    public float MoveSpeed = 10.0f;
    public GameObject Explosion;
    public float frequency = 200.0f;  // Speed of sine movement
    public float magnitude = 100f;   // Size of sine movement
    private Vector3 axis;
    public float change_dir = 1;
    private Vector3 pos;

    void Start()
    {
        pos = transform.position;
        axis = transform.up;  // May or may not be the axis you want

    }

    void Update()
    {

        pos += (transform.right * Time.deltaTime * MoveSpeed) * change_dir;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
        if (change_dir < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Wall")
        {
            change_dir = -1 * change_dir;
            Debug.Log("touchwall");
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "BulletTag")
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