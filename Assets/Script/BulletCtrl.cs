using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float bullet_speed_x;
    public  float bullet_speed_y;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 position = transform.position;

        position = new Vector2(position.x + bullet_speed_x * Time.deltaTime, position.y + bullet_speed_y * Time.deltaTime);

        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > max.x)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < min.x)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyTag")
        {
            Destroy(gameObject);
        }
    }
}
