using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour{

    public float attackRate = 1;
    public float attack = 5;
    private float timer;
    private EnemyHealth health;

    void Start(){
        timer = 1 / attackRate;
        health = this.GetComponent<EnemyHealth>();
    }

    public void OnTriggerStay(Collider collider){
        if (collider.tag == Tags.player && health.hp > 0){
            timer += Time.deltaTime;
            if (timer >= 1 / attackRate){
                timer -= 1 / attackRate;
                collider.GetComponent<PlayerHealth>().TakeDamage(attack);
            }
        }
    }
}