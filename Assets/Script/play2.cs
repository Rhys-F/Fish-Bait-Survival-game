using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class play2 : MonoBehaviour {


	public float speed = 30;
	private float movex = 0f;
	private float movey = 0f;
	public float moving_speed;
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
	float timeSpawn = 0;
	float timeMove = 5;
	public float spawnRate = 10;
	public float moveRate = 1;
	private GameObject[] getCount;
	Transform firePos;
	public AudioClip shootSound;
	private AudioSource source;
	public AudioClip explosion;
	private AudioSource source2;


    // Use this for initialization
    void Start()
    {
		firePos = transform.FindChild("firePos");
		rb = GetComponent<Rigidbody2D>();
		topSpeed = 25;
		maxAccel = 50;
		Vector2 wrld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0.0f));
		source = GetComponent<AudioSource> ();
		source2 = GetComponent<AudioSource> ();
    }


    // Update is called once per frame
    void FixedUpdate()
    {


        var move = new Vector3(movex, movey, 0);
        rb.AddForce(move * maxAccel);
        var speed = rb.velocity;
        var noMove = new Vector3(0, 0, 0);
        if (move != noMove)
        {
            float angle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        if (speed.magnitude > topSpeed)
        {
            rb.velocity = speed * (topSpeed / rb.velocity.magnitude);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            Fire();
        }

        //rb.velocity = move * topSpeed;

    }

    void movement()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            movey = moving_speed;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            movey = -moving_speed;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            movex = -moving_speed;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            movex = moving_speed;
        }

    }
    void Update()
    {

        movement();

        if (Time.time >= timeMove)
        {
            movex = 0;
            movey = 0;
            timeMove = Time.time + 1 / moveRate;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            facing = "U";
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            facing = "D";
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            facing = "L";
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            facing = "R";
        }
        if (Input.GetKeyDown(KeyCode.I) && Input.GetKeyDown(KeyCode.J))
        {
            facing = "UL";
        }
        if (Input.GetKeyDown(KeyCode.I) && Input.GetKeyDown(KeyCode.L))
        {
            facing = "UR";
        }
        if (Input.GetKeyDown(KeyCode.K) && Input.GetKeyDown(KeyCode.L))
        {
            facing = "DR";
        }
        if (Input.GetKeyDown(KeyCode.K) && Input.GetKeyDown(KeyCode.J))
        {
            facing = "DL";
        }
        getCount = GameObject.FindGameObjectsWithTag("EnemyTag");
        int count = getCount.Length;
        if (count == 0)
        {
            Debug.Log("You Win");
            SceneManager.LoadScene("wave 3", LoadSceneMode.Additive);
        }
    }
    void Fire()
    {


        if (Time.time >= timeSpawn)
        {
            Effect();
			source.PlayOneShot (shootSound, 1);
            timeSpawn = Time.time + 1 / spawnRate;
        }
    }

    void Effect()
    {
        if (facing == "U")
        {
            Instantiate(bulletU, firePos.position, Quaternion.identity);

        }
        if (facing == "D")
        {
            Instantiate(bulletD, firePos.position, Quaternion.identity);
        }
        if (facing == "L")
        {
            Instantiate(bullet, firePos.position, Quaternion.identity);
        }
        if (facing == "R")
        {
            Instantiate(bulletR, firePos.position, Quaternion.identity);
        }
        if (facing == "UL")
        {
            Instantiate(bulletUL, firePos.position, Quaternion.identity);
        }
        if (facing == "UR")
        {
            Instantiate(bulletUR, firePos.position, Quaternion.identity);
        }
        if (facing == "DL")
        {
            Instantiate(bulletDL, firePos.position, Quaternion.identity);
        }
        if (facing == "DR")
        {
            Instantiate(bulletDR, firePos.position, Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "EnemyTag")
        {
            Debug.Log("Touch");
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