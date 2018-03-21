using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject enemyPrefab;
    public float spawnTime = 10;
    public float accrate = 5;
    private float timer = 10;
    private PlayerHealth playerHealth;
    private PlayerShoot playerShoot;

    void Awake(){
        playerHealth = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerHealth>();
        playerShoot = GameObject.FindGameObjectWithTag(Tags.player).GetComponentInChildren<PlayerShoot>();
    }

    void Start(){
        InvokeRepeating("ACC",5,accrate);
    }

    void Update(){
        timer += Time.deltaTime;
        if (timer >= spawnTime&&playerHealth.hp>0&&playerShoot.totalClearedNum<playerShoot.targetNum){
            timer -= spawnTime;
            SpawnEnemy();
        }
    }

    void SpawnEnemy(){
        GameObject.Instantiate(enemyPrefab, transform.position, transform.rotation);
    }

    void ACC(){
        spawnTime -= 0.05f;
    }
}
