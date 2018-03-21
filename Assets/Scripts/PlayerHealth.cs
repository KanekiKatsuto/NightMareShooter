using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	// Use this for initialization
    public float fullHp = 100;
    public float hp = 100;
    public float smoothing = 5;
    public AudioClip deathClip;
    private Animator anim;
    private PlayerMove playerMove;
    private PlayerShoot playerShoot;
    private SkinnedMeshRenderer bodyRenderer;

    void Awake(){
        anim = this.GetComponent<Animator>();
        this.playerMove = this.GetComponent<PlayerMove>();
        this.playerShoot = this.GetComponentInChildren<PlayerShoot>();
        this.bodyRenderer = transform.Find("Player").GetComponent<Renderer>() as SkinnedMeshRenderer;
    }

    void Update(){
        bodyRenderer.material.color = Color.Lerp(bodyRenderer.material.color, Color.white, smoothing * Time.deltaTime);
    }

    public void TakeDamage(float damage){
        if (hp <= 0) return;
        this.GetComponent<AudioSource>().Play();
        this.hp -= damage;
        bodyRenderer.material.color = Color.red;
        if (this.hp <= 0){
            Dead();
        }
    }

    void Dead(){
        anim.SetBool("Dead", true);
        AudioSource.PlayClipAtPoint(deathClip, transform.position, 1);
        this.playerMove.enabled = false;
        this.playerShoot.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
}
