using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	// Use this for initialization
    public float stopDistance = 1.5f;
    public float berserkerNum = 40;
    public float berserkerRate = 1;
    private NavMeshAgent agent;
    private Transform player;
    private Animator anim;
    private PlayerShoot playerShoot;
    private PlayerHealth playerHealth;

	void Awake () {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        playerShoot = GameObject.FindGameObjectWithTag(Tags.player).GetComponentInChildren<PlayerShoot>();
        playerHealth = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerHealth>();
	}

    void Start(){
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(player.position);
        if (Vector3.Distance(transform.position, player.position) < stopDistance){
            anim.SetBool("Move", false);
        }else{
            anim.SetBool("Move", true);
        }
        if (playerShoot.totalClearedNum >= berserkerNum){
            agent.speed += berserkerRate;
            berserkerNum = 1000;
        }
        if (playerHealth.hp <= 0){
            anim.SetBool("Move", false);
            agent.Stop();
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
	}
}
