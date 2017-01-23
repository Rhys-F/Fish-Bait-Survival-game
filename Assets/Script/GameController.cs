using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject FishnormalFish_diff_1;
    public GameObject FishnormalFish_diff_2;
    public Vector2 spawnvalues;
    public int enemiesCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    float timer = 0;

    // Use this for initialization
	void Start () {
        //StartCoroutine (SpawnWaves());
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] aliveEnemies1 = GameObject.FindGameObjectsWithTag("EnemyTag");
        Debug.Log(aliveEnemies1.Length);
        if(aliveEnemies1.Length == 0){

            timer += Time.deltaTime;
            if(timer >= startWait)
            {
                for (int i = 0; i < enemiesCount; i++)
                {
                    Vector2 spawnposition = new Vector2(Random.Range(-spawnvalues.x, spawnvalues.x), Random.Range(-spawnvalues.y, spawnvalues.y));
                    Instantiate(FishnormalFish_diff_1, spawnposition, new Quaternion());
                }
                for (int i = 3; i < enemiesCount; i++)
                {
                    Vector2 spawnposition = new Vector2(Random.Range(-spawnvalues.x, spawnvalues.x), Random.Range(-spawnvalues.y, spawnvalues.y));
                    Instantiate(FishnormalFish_diff_2, spawnposition, new Quaternion());
                }
                timer = 0;
                enemiesCount += 1;
            }
        }      
    }
}
