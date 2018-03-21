using UnityEngine;
using System.Collections;

public class Explore : MonoBehaviour {

    public float radius = 5;
    public float bombSpeed = 800;
    public float exploreDamage = 100;
    public AudioClip bombClip;
    private ParticleSystem particleSystem;

    void Awake(){
        this.GetComponent<Rigidbody>().AddForce(GameObject.FindGameObjectWithTag(Tags.gunBarrelEnd).transform.forward * bombSpeed);
        this.particleSystem = this.GetComponentInChildren<ParticleSystem>();
    }

    public void OnCollisionEnter(Collision collision){
        if (collision.collider.transform.tag!=Tags.ground){
            this.particleSystem.transform.position = collision.transform.position;
            this.particleSystem.Play();
            AudioSource.PlayClipAtPoint(bombClip, collision.transform.position, 1);
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders){
                if (hit.transform.tag == Tags.enemy){
                    hit.GetComponent<EnemyHealth>().TakeDamage(exploreDamage, hit.transform.position);
                }
            }
        }
        Invoke("BombDestroy", 0.1f);
    }

    void BombDestroy(){
        Destroy(this.gameObject);
    }
}
