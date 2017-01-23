using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    public GameObject Explosion;

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
