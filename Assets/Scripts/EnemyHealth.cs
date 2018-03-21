using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	// Use this for initialization
    public float hp = 100;
    public float fullHp = 100;
    public AudioClip deathClip;
    public float berserkerNum = 40;
    private Animator anim;
    private NavMeshAgent agent;
    private EnemyMove enemyMove;
    private EnemyAttack enemyAttack;
    private ParticleSystem particleSystem;
    private PlayerShoot playerShoot;
    private SkinnedMeshRenderer bodyRenderer;

    void Awake(){
        anim = this.GetComponent<Animator>();
        agent = this.GetComponent<NavMeshAgent>();
        enemyMove = this.GetComponent<EnemyMove>();
        enemyAttack = this.GetComponent<EnemyAttack>();
        particleSystem = this.GetComponentInChildren<ParticleSystem>();
        playerShoot = GameObject.FindGameObjectWithTag(Tags.player).GetComponentInChildren<PlayerShoot>();
        this.bodyRenderer = transform.Find("EnemyBody").GetComponent<Renderer>() as SkinnedMeshRenderer;
    }

    void Update(){
        if (this.hp <= 0){
            transform.Translate(Vector3.down * Time.deltaTime * 0.5f);
            if (transform.position.y <= -2){
                Destroy(this.gameObject);
            }
        }
        if (playerShoot.totalClearedNum >= berserkerNum){
            foreach (Material mate in bodyRenderer.materials){
                mate.color = Color.red;
            }
        }
        if (playerShoot.totalClearedNum >= enemyMove.berserkerNum){
            this.hp *= 2;
            enemyMove.berserkerNum = 1000;
        }
    }

    public void TakeDamage(float damage,Vector3 hitPoint){
        if (hp <= 0) return;
        particleSystem.transform.position = hitPoint;
        particleSystem.Play();
        this.GetComponent<AudioSource>().Play();
        this.hp -= damage;
        if (this.hp <= 0){
            Dead();
        }
    }

    void Dead(){
        anim.SetBool("Dead", true);
        AudioSource.PlayClipAtPoint(deathClip, transform.position, 1);
        agent.enabled = false;
        enemyMove.enabled = false;
        enemyAttack.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        playerShoot.clearedNumForBomb++;
        playerShoot.totalClearedNum++;
    }
}
