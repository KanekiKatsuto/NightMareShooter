using UnityEngine;
using System.Collections;

public class ShowEnemyHp : MonoBehaviour {

    public float fullLength = 0.3f;
    private EnemyHealth enemyHealth;

	// Use this for initialization
	void Awake () {
        enemyHealth = this.GetComponentInParent<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.localScale = new Vector3(0.05f, fullLength * enemyHealth.hp / enemyHealth.fullHp, 0.05f);
        if (enemyHealth.hp <= 0){
            Destroy(this.gameObject);
        }
	}
}
