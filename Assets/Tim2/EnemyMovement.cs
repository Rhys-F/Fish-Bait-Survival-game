using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	public float topSpeed;
	public Rigidbody2D rb;
    public GameObject Explosion;
    // Use this for initialization
    void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		topSpeed = 10;
		var move = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
		rb.AddForce (move * 100);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		var speed = rb.velocity;
		if (speed.magnitude != topSpeed) {
			if (speed.magnitude != 0) {
				rb.velocity = speed * (topSpeed / rb.velocity.magnitude);
			}
		}

        if (rb.velocity.x >= 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        //if right
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
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
