using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	// Use this for initialization
    public float attack = 30;
    public GameObject bomb;
    public float bombNum = 0;
    public float bombTime = 10;
    public float clearedNumForBomb = 0;
    public float clearedNumForBombAdd = 10;
    public float totalClearedNum = 0;
    public float targetNum = 60;
    private float timer = 0;
    private ParticleSystem particleSystem;
    private LineRenderer lineRenderer;

	void Start () {
        particleSystem = this.GetComponentInChildren<ParticleSystem>();
        lineRenderer = this.GetComponent<Renderer>() as LineRenderer;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)){
            Shoot();
        }
        timer += Time.deltaTime;
        if (timer >= bombTime){
            bombNum++;
            timer -= bombTime;
        }
        if (clearedNumForBomb>=clearedNumForBombAdd){
            bombNum++;
            clearedNumForBomb -= clearedNumForBombAdd;
        }
        if (Input.GetMouseButtonDown(1)&&bombNum>0){
            Launch();
            bombNum--;
        }
	}

    void Shoot(){
        GetComponent<Light>().enabled = true;
        particleSystem.Play();
        this.lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo)){
            lineRenderer.SetPosition(1, hitInfo.point);
            if (hitInfo.collider.tag == Tags.enemy){
                hitInfo.collider.GetComponent<EnemyHealth>().TakeDamage(attack,hitInfo.point);
            }
        }else{
            lineRenderer.SetPosition(1, transform.position+transform.forward*200);
        }
        this.GetComponent<AudioSource>().Play();
        Invoke("ClearEffect", 0.05f);
    }

    void Launch(){
        GetComponent<Light>().enabled = true;
        particleSystem.Play();
        GameObject.Instantiate(bomb, transform.position + transform.forward * 0.08f, transform.rotation);
        this.GetComponent<AudioSource>().Play();
        Invoke("ClearEffect1", 0.05f);
    }

    void ClearEffect(){
        GetComponent<Light>().enabled = false;
        lineRenderer.enabled = false;
    }

    void ClearEffect1(){
        GetComponent<Light>().enabled = false;
    }
}
